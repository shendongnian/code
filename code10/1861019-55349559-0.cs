    ```
    // For generating frequencies
    namespace FG
    {
        /// <summary>
        /// Provides application-specific behavior to supplement the default Application class.
        /// </summary>
        sealed partial class App : Application
        {
            // For audio nodes through which audio data flows
            static AudioGraph audioGraph;
            // Pushes audio data that is generated
            static AudioFrameInputNode frameInputNode;
            // Pitch in hz
            static float pitch = 1000;
            // For audio out
            AudioDeviceOutputNode deviceOutputNode;
            // Access to the underlying memory buffer
            [ComImport]
            [Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            unsafe interface IMemoryBufferByteAccess
            {
                void GetBuffer(out byte* buffer, out uint capacity);
            }
    
            /// <summary>
            /// Initializes the singleton application object.  This is the first line of authored code
            /// executed, and as such is the logical equivalent of main() or WinMain().
            /// </summary>
            public App()
            {
                this.InitializeComponent();
                // Setup audio pipeline
                InitAudioGraph().Wait();
                // For audio playback
                CreateDeviceOutputNode().Wait();
                // of audio frames
                CreateFrameInputNode();
                frameInputNode.AddOutgoingConnection(deviceOutputNode);
                this.Suspending += OnSuspending;
            }
    
            // Initializes AudioGraph
            public async Task InitAudioGraph()
            {
                AudioGraphSettings settings = new AudioGraphSettings(AudioRenderCategory.Media);
                            CreateAudioGraphResult result = await 
                            AudioGraph.CreateAsync(settings);
                audioGraph = result.Graph;
            }
    
            // Creates an AudioDeviceOutputNode for sending audio to playback device
            private async Task CreateDeviceOutputNode()
            {
                // Create a device output node
                CreateAudioDeviceOutputNodeResult result = await audioGraph.CreateDeviceOutputNodeAsync();
                deviceOutputNode = result.DeviceOutputNode;
            }
    
            // Creates FrameInputNode for taking in audio frames
            private void CreateFrameInputNode()
            {
                // Create the FrameInputNode at the same format as the graph, except explicitly set mono.
                AudioEncodingProperties nodeEncodingProperties = audioGraph.EncodingProperties;
                frameInputNode = audioGraph.CreateFrameInputNode(nodeEncodingProperties);
                // Initialize the Frame Input Node in the stopped state
                frameInputNode.Stop();
                // Hook up an event handler so we can start generating samples when needed
                // This event is triggered when the node is required to provide data
                frameInputNode.QuantumStarted += node_QuantumStarted;
            }
    
            // For creating audio frames on the fly
            private void node_QuantumStarted(AudioFrameInputNode sender, FrameInputNodeQuantumStartedEventArgs args)
            {
                // GenerateAudioData can provide PCM audio data by directly synthesizing it or reading from a file.
                // Need to know how many samples are required. In this case, the node is running at the same rate as the rest of the graph
                // For minimum latency, only provide the required amount of samples. Extra samples will introduce additional latency.
                uint numSamplesNeeded = (uint)args.RequiredSamples;
                if (numSamplesNeeded != 0)
                {
                    AudioFrame audioData = GenerateAudioData(numSamplesNeeded);
                    frameInputNode.AddFrame(audioData);
                }
            }
    
            // Generate audioframes for the audiograph
            unsafe private AudioFrame GenerateAudioData(uint samples)
            {
                // Buffer size is (number of samples) * (size of each sample)
                // We choose to generate single channel (mono) audio. For multi-channel, multiply by number of channels
                uint bufferSize = samples * frameInputNode.EncodingProperties.BitsPerSample;
                AudioFrame frame = new Windows.Media.AudioFrame(bufferSize);
    
                using (AudioBuffer buffer = frame.LockBuffer(AudioBufferAccessMode.Write))
                using (IMemoryBufferReference reference = buffer.CreateReference())
                {
                    byte* dataInBytes;
                    uint capacityInBytes;
                    float* dataInFloat;
    
                    // Get the buffer from the AudioFrame
                    ((IMemoryBufferByteAccess)reference).GetBuffer(out dataInBytes, out capacityInBytes);
    
                    // Cast to float since the data we are generating is float
                    dataInFloat = (float*)dataInBytes;
    
                    float amplitude = 0.3f;
                    int sampleRate = (int)audioGraph.EncodingProperties.SampleRate;
                    double sampleIncrement = ((pitch*2*Math.PI)/sampleRate);
    
                    // Generate a 1kHz sine wave and populate the values in the memory buffer
                    for (int i = 0; i < samples; i++)
                    {
                        double sinValue = amplitude * Math.Sin(i*sampleIncrement);
                        dataInFloat[i] = (float)sinValue;
                    }
                }
    
                return frame;
            }
    
            /// <summary>
            /// Invoked when the application is launched normally by the end user.  Other entry points
            /// will be used such as when the application is launched to open a specific file.
            /// </summary>
            /// <param name="e">Details about the launch request and process.</param>
            protected override void OnLaunched(LaunchActivatedEventArgs e)
            {
                Frame rootFrame = Window.Current.Content as Frame;
    
                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    rootFrame = new Frame();
    
                    rootFrame.NavigationFailed += OnNavigationFailed;
    
                    if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                    {
                        //TODO: Load state from previously suspended application
                    }
    
                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
                }
    
                if (e.PrelaunchActivated == false)
                {
                    if (rootFrame.Content == null)
                    {
                        // When the navigation stack isn't restored navigate to the first page,
                        // configuring the new page by passing required information as a navigation
                        // parameter
                        rootFrame.Navigate(typeof(MainPage), e.Arguments);
                    }
                    // Ensure the current window is active
                    Window.Current.Activate();
                }
            }
    
            /// <summary>
            /// Invoked when Navigation to a certain page fails
            /// </summary>
            /// <param name="sender">The Frame which failed navigation</param>
            /// <param name="e">Details about the navigation failure</param>
            void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
            {
                throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
            }
    
            /// <summary>
            /// Invoked when application execution is being suspended.  Application state is saved
            /// without knowing whether the application will be terminated or resumed with the contents
            /// of memory still intact.
            /// </summary>
            /// <param name="sender">The source of the suspend request.</param>
            /// <param name="e">Details about the suspend request.</param>
            private void OnSuspending(object sender, SuspendingEventArgs e)
            {
                var deferral = e.SuspendingOperation.GetDeferral();
                //TODO: Save application state and stop any background activity
                deferral.Complete();
            }
    
            internal static void setPitch(float value)
            {
                pitch = value;
            }
    
            internal static void StartNoise()
            {
                frameInputNode.Start();
                audioGraph.Start();
            }
    
            internal static void StopNoise()
            {
                frameInputNode.Stop();
                audioGraph.Stop();    
            }
        }
    }
    ```
    namespace FG
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
    
            public MainPage()
            {
                this.InitializeComponent();
                Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
                Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
            }
    
            void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
            {
                if (args.VirtualKey == VirtualKey.A)
                {
                    App.StartNoise();
                }
            }
    
            void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
            {
                if (args.VirtualKey == VirtualKey.A)
                {
                    App.StopNoise();
                }
            }
    
            private void PitchTextChanged(object sender, TextChangedEventArgs e)
            {
                try
                {
                    App.setPitch(float.Parse(((TextBox)sender).Text));
                }
                catch(FormatException)
                {
    
                }
            }
        }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
    
        // (...)
    
        /// <summary>
        /// Sent as a signal that a window or an application should terminate.
        /// </summary>
        const uint WM_CLOSE = 0x0010;
    
        /// <summary>
        /// Retrieves a message from the calling thread's message queue. The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// </summary>
        /// <param name="lpMsg">MSG structure that receives message information from the thread's message queue.</param>
        /// <param name="hWnd">A handle to the window whose messages are to be retrieved. The window must belong to the current thread. Use <see cref="IntPtr.Zero"/> to retrieve thread message.</param>
        /// <param name="wMsgFilterMin">The integer value of the lowest message value to be retrieved.</param>
        /// <param name="wMsgFilterMax">The integer value of the highest message value to be retrieved.</param>
        /// <returns>Non-zero for any message but WM_QUIT, zero for WM_QUIT, -1 for error.</returns>
        [DllImport("user32.dll")]
        static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
    
        /// <summary>
        /// Waits indefinitely for a specific thread message.
        /// </summary>
        /// <param name="signal">Signal, message value.</param>
        private void WaitForSignal(uint signal) => GetMessage(out var msg, IntPtr.Zero, signal, signal);
    
        /// <summary>
        /// WPF application startup.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override async void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            // ... initialization code ...
            await Task.Run(() => WaitForSignal(WM_CLOSE));
            Shutdown();
        }
    
        // (...)
    
    }

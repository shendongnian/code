    public sealed class StartupTask : IBackgroundTask
        {
            private static BackgroundTaskDeferral _Deferral = null;
            private static TestWebserver webserver = null;
            private static MasterEventListener masterEventListener = null;
            private static I2CEventsListener i2cEventListener = null;
    
            public async void Run(IBackgroundTaskInstance taskInstance)
            {
                _Deferral = taskInstance.GetDeferral();
    
                // do some stuff on the main thread here...
    
                // thread 1
                webserver = new TestWebserver();
                await Windows.System.Threading.ThreadPool.RunAsync(workItem =>
                {
                    webserver.Start();
                });
    
                // thread 2
                masterEventListener = new MasterEventListener();
                await Windows.System.Threading.ThreadPool.RunAsync(workItem =>
                {
                    masterEventListener.Start();
                });
    
                // thread 3
                i2cEventListener = new I2CEventsListener();
                await Windows.System.Threading.ThreadPool.RunAsync(workItem =>
                {
                    i2cEventListener.Start();
                });
    
                Debug.WriteLine("The Run method exit...");
            }
    
            internal class TestWebserver
            {
                private StreamSocketListener listener = null;
                private const uint BufferSize = 8192;
                public async void Start()
                {
                    listener = new StreamSocketListener();
                    await listener.BindServiceNameAsync("8081");
    
                    listener.ConnectionReceived += async (sender, args) =>
                    {
                        var request = new StringBuilder();
                        using (var input = args.Socket.InputStream)
                        {
                            var data = new byte[BufferSize];
                            IBuffer buffer = data.AsBuffer();
                            var dataRead = BufferSize;
    
                            while (dataRead == BufferSize)
                            {
                                await input.ReadAsync(buffer, BufferSize, InputStreamOptions.Partial);
                                request.Append(Encoding.UTF8.GetString(data, 0, data.Length));
                                dataRead = buffer.Length;
                            }
                        }
    
                        using (var output = args.Socket.OutputStream)
                        {
                            using (var response = output.AsStreamForWrite())
                            {
                                string html = "TESTING RESPONSE";
                                using (var bodyStream = new MemoryStream(Encoding.ASCII.GetBytes(html)))
                                {
                                    var header = $"HTTP/1.1 200 OK\r\nContent-Length: {bodyStream.Length}\r\n\r\nConnection: close\r\n\r\n";
                                    var headerArray = Encoding.UTF8.GetBytes(header);
                                    await response.WriteAsync(headerArray, 0, headerArray.Length);
                                    await bodyStream.CopyToAsync(response);
                                    await response.FlushAsync();
                                }
                            }
                        }
                    };
                }
            }
    
            internal class MasterEventListener
            {
                private GpioController gpio = null;
                private GpioPin gpioPin = null;
    
                public void Start()
                {
    
                    gpio = GpioController.GetDefault();
                    gpioPin = gpio.OpenPin(4); // pin4
    
                    if (gpioPin.IsDriveModeSupported(GpioPinDriveMode.InputPullUp))
                    {
                        gpioPin.SetDriveMode(GpioPinDriveMode.InputPullUp);
                    }
                    else
                    {
                        gpioPin.SetDriveMode(GpioPinDriveMode.Input);
                    }
    
                    gpioPin.Write(GpioPinValue.High);
                    gpioPin.DebounceTimeout = TimeSpan.FromMilliseconds(25);
                    gpioPin.ValueChanged += Pin_ValueChanged;
                }
    
                private void Pin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
                {
                    bool value = sender.Read() == GpioPinValue.High;
    
                    if (value)
                    {
                        Debug.WriteLine("OPEN!");
                    }
                    else
                    {
                        Debug.WriteLine("CLOSED!");
                    }
                }
            }
    
            internal class I2CEventsListener
            {
                public async void Start()
                {
                    string aqs = I2cDevice.GetDeviceSelector();
                    DeviceInformationCollection dis = await DeviceInformation.FindAllAsync(aqs);
    
                    I2CThreadListener(dis);
                }
    
                private async void I2CThreadListener(DeviceInformationCollection dis)
                {
                    var settings = new I2cConnectionSettings(3); // I2C address 3
                    settings.BusSpeed = I2cBusSpeed.FastMode;
                    settings.SharingMode = I2cSharingMode.Shared;
    
                    I2cDevice device = await I2cDevice.FromIdAsync(dis[0].Id, settings);
                    if (null == device)
                    {
                        Debug.WriteLine("Get I2C device is NULL. Exiting...");
                    }
    
                    byte[] writeBuffer = Encoding.ASCII.GetBytes("000000");
                    byte[] readBuffer = new byte[7];
    
                    while (true)
                    {
                        try
                        {
                            device.Write(writeBuffer);
                            device.Read(readBuffer);
    
                            var str = Encoding.Default.GetString(readBuffer);
                            if (str != null && str.Trim().Length == 7 && Convert.ToInt32(readBuffer[0]) > 0)
                            {
                                Debug.WriteLine("RESULTS! '" + str + "'");
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                            Debug.WriteLine(ex.StackTrace);
                        }
    
                        Thread.Sleep(100);
                    }
                }
            }
    
    
        }

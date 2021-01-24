        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {
            try
            {
                var device = await BluetoothDevice.FromIdAsync(args.Id);
                var services = await device.GetRfcommServicesAsync();
                if (services.Services.Count > 0)
                {
                    var service = services.Services[0];
                    stream = new StreamSocket();
                    await stream.ConnectAsync(service.ConnectionHostName, service.ConnectionServiceName);
                    rx = new DataReader(stream.InputStream);
                    tx = new DataWriter(stream.OutputStream);
                    await this.Dispatcher.RunAsync(
                        Windows.UI.Core.CoreDispatcherPriority.Normal,
                        () => { Device_9.IsEnabled = true; });
                    deviceWatcher.Stop();
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

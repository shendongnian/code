        private IDictionary<string, string> GetDeviceIds()
        {
            var deviceIds = new Dictionary<string, string>();
            var devices = new PortableDeviceCollection();
            devices.Refresh();
            foreach (var device in devices)
            {
                device.Connect();
                deviceIds.Add(device.FriendlyName, device.DeviceId);
                Console.WriteLine(@"DeviceId: {0}, FriendlyName: {1}", device.DeviceId, device.FriendlyName);
                device.Disconnect();
            }
            return deviceIds;
        }

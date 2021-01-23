        public Task<IEnumerable<ConnectedDeviceDefinition>> GetConnectedDeviceDefinitions(FilterDeviceDefinition deviceDefinition)
        {
            return Task.Run<IEnumerable<ConnectedDeviceDefinition>>(() =>
            {
                //TODO: Get more details about the device.
                return UsbManager.DeviceList.Select(kvp => kvp.Value).Where(d => deviceDefinition.VendorId == d.VendorId && deviceDefinition.ProductId == d.ProductId).Select(GetAndroidDeviceDefinition).ToList();
            });
        }

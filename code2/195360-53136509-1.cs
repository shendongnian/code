          public static async Task<wde.DeviceInformationCollection> GetAllDevices()
            {
                return await wde.DeviceInformation.FindAllAsync().AsTask();
            }
    
            private async Task<List<wde.DeviceInformation>> GetDevicesByIdSlowAsync()
            {
                var allDevices = await GetAllDevices();
    
                Logger.Log($"Device Ids:{string.Join(", ", allDevices.Select(d => d.Id))} Names:{string.Join(", ", allDevices.Select(d => d.Name))}", null, nameof(UWPHidDevicePoller));
    
                var vendorIdString = $"VID_{ VendorId.ToString("X").PadLeft(4, '0')}".ToLower();
                var productIdString = $"PID_{ ProductId.ToString("X").PadLeft(4, '0')}".ToLower();
    
                return allDevices.Where(args => args.Id.ToLower().Contains(vendorIdString) && args.Id.ToLower().Contains(productIdString) && args.IsEnabled).ToList();
    }

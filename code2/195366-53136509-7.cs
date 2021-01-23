        public async Task<IEnumerable<ConnectedDeviceDefinition>> GetConnectedDeviceDefinitions(FilterDeviceDefinition deviceDefinition)
        {
            var aqsFilter = GetAqsFilter(deviceDefinition.VendorId, deviceDefinition.ProductId);
            var deviceInformationCollection = await wde.DeviceInformation.FindAllAsync(aqsFilter).AsTask();
            var deviceDefinitions = deviceInformationCollection.Select(d => GetDeviceInformation(d, DeviceType));
            var deviceDefinitionList = new List<ConnectedDeviceDefinition>();
            foreach (var deviceDef in deviceDefinitions)
            {
                var connectionInformation = await TestConnection(deviceDef.DeviceId);
                if (connectionInformation.CanConnect)
                {
                    await Task.Delay(1000);
                    deviceDef.UsagePage = connectionInformation.UsagePage;
                    deviceDefinitionList.Add(deviceDef);
                }
            }
            return deviceDefinitionList;
        }

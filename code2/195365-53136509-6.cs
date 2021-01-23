        public static ConnectedDeviceDefinition GetDeviceDefinition(string deviceId, SafeFileHandle safeFileHandle)
        {
            try
            {
                var hidAttributes = GetHidAttributes(safeFileHandle);
                var hidCollectionCapabilities = GetHidCapabilities(safeFileHandle);
                var manufacturer = GetManufacturer(safeFileHandle);
                var serialNumber = GetSerialNumber(safeFileHandle);
                var product = GetProduct(safeFileHandle);
                return new ConnectedDeviceDefinition(deviceId)
                {
                    WriteBufferSize = hidCollectionCapabilities.OutputReportByteLength,
                    ReadBufferSize = hidCollectionCapabilities.InputReportByteLength,
                    Manufacturer = manufacturer,
                    ProductName = product,
                    ProductId = (ushort)hidAttributes.ProductId,
                    SerialNumber = serialNumber,
                    Usage = hidCollectionCapabilities.Usage,
                    UsagePage = hidCollectionCapabilities.UsagePage,
                    VendorId = (ushort)hidAttributes.VendorId,
                    VersionNumber = (ushort)hidAttributes.VersionNumber,
                    DeviceType = DeviceType.Hid
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

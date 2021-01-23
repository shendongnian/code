            DeviceManager manager = new DeviceManagerClass();
            DeviceInfo scannerInfo = WiaHelper.FindFirstScanner(manager);
            Device device = scannerInfo.Connect();
            Item item = device.Items[1];
        public static DeviceInfo FindFirstScanner(DeviceManager manager)
        {
            DeviceInfos infos = manager.DeviceInfos;
            foreach (DeviceInfo info in infos)
                if (info.Type == WiaDeviceType.ScannerDeviceType)
                    return info;
            return null;
        }
        public static Property FindProperty(WIA.Properties properties, int propertyId)
        {
            foreach (Property property in properties)
                if (property.PropertyID == propertyId)
                    return property;
            return null;
        }
        public static void SetDeviceProperty(Device device, int propertyId, object value)
        {
            Property property = FindProperty(device.Properties, propertyId);
            if (property != null)
                property.set_Value(value);
        }
        public static object GetDeviceProperty(Device device, int propertyId)
        {
            Property property = FindProperty(device.Properties, propertyId);
            return property != null ? property.get_Value() : null;
        }
        public static object GetItemProperty(Item item, int propertyId)
        {
            Property property = FindProperty(item.Properties, propertyId);
            return property != null ? property.get_Value() : null;
        }
        public static void SetItemProperty(Item item, int propertyId, object value)
        {
            Property property = FindProperty(item.Properties, propertyId);
            if (property != null)
                property.set_Value(value);
        }

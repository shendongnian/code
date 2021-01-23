        public enum DeviceDocumentHandling : int
        {
            Feeder = 1,
            FlatBed = 2
        }
        const int DEVICE_PROPERTY_DOCUMENT_HANDLING_CAPABILITIES_ID = 3086;
        const int DEVICE_PROPERTY_DOCUMENT_HANDLING_STATUS_ID = 3087;
        const int DEVICE_PROPERTY_DOCUMENT_HANDLING_SELECT_ID = 3088;
        const int DEVICE_PROPERTY_PAGES_ID = 3096;
        public static Property FindProperty(WIA.Properties properties, 
                                            int propertyId)
        {
            foreach (Property property in properties)
                if (property.PropertyID == propertyId)
                    return property;
            return null;
        }
        public static void SetDeviceProperty(Device device, int propertyId, 
                                             object value)
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
        public static void SelectDeviceDocumentHandling(Device device, 
                                    DeviceDocumentHandling handling)
        {
            int requested = (int)handling;
            int supported = (int)GetDeviceProperty(device, 
                     DEVICE_PROPERTY_DOCUMENT_HANDLING_CAPABILITIES_ID);
            if ((requested & supported) != 0)
            {
                if ((requested & (int)DeviceDocumentHandling.Feeder) != 0)
                    SetDeviceProperty(device, DEVICE_PROPERTY_PAGES_ID, 1);
                SetDeviceProperty(device, 
                       DEVICE_PROPERTY_DOCUMENT_HANDLING_SELECT_ID, requested);
            }
        }

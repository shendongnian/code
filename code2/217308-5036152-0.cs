        const string CAPTURE = "•GeoVision GV-800A";
        s_CaptureDevices = BuildDeviceList(FilterCategory.AMKSCapture, CAPTURE);
        private static List<DsDevice> BuildDeviceList(Guid category, string name)
        {
            var list = new List<DsDevice>();
            DsDevice[] devices = DsDevice.GetDevicesOfCat(category);
            for (int i = 0; i < devices.Length; i++)
            {
                if (!string.IsNullOrEmpty(devices[i].Name) && devices[i].Name.Equals(name))
                {
                    list.Add(devices[i]);
                }
            }
            return list;
        }

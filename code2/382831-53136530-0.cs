            public static Collection<DeviceInformation> GetConnectedDeviceInformations()
            {
                var deviceInformations = new Collection<DeviceInformation>();
                var spDeviceInterfaceData = new SpDeviceInterfaceData();
                var spDeviceInfoData = new SpDeviceInfoData();
                var spDeviceInterfaceDetailData = new SpDeviceInterfaceDetailData();
                spDeviceInterfaceData.CbSize = (uint)Marshal.SizeOf(spDeviceInterfaceData);
                spDeviceInfoData.CbSize = (uint)Marshal.SizeOf(spDeviceInfoData);
    
                var hidGuid = new Guid();
    
                APICalls.HidD_GetHidGuid(ref hidGuid);
    
                var i = APICalls.SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, APICalls.DigcfDeviceinterface | APICalls.DigcfPresent);
    
                if (IntPtr.Size == 8)
                {
                    spDeviceInterfaceDetailData.CbSize = 8;
                }
                else
                {
                    spDeviceInterfaceDetailData.CbSize = 4 + Marshal.SystemDefaultCharSize;
                }
    
                var x = -1;
    
                while (true)
                {
                    x++;
    
                    var setupDiEnumDeviceInterfacesResult = APICalls.SetupDiEnumDeviceInterfaces(i, IntPtr.Zero, ref hidGuid, (uint)x, ref spDeviceInterfaceData);
                    var errorNumber = Marshal.GetLastWin32Error();
    
                    //TODO: deal with error numbers. Give a meaningful error message
    
                    if (setupDiEnumDeviceInterfacesResult == false)
                    {
                        break;
                    }
    
                    APICalls.SetupDiGetDeviceInterfaceDetail(i, ref spDeviceInterfaceData, ref spDeviceInterfaceDetailData, 256, out _, ref spDeviceInfoData);
    
                    var deviceInformation = GetDeviceInformation(spDeviceInterfaceDetailData.DevicePath);
                    if (deviceInformation == null)
                    {
                        continue;
                    }
    
                    deviceInformations.Add(deviceInformation);
                }
    
                APICalls.SetupDiDestroyDeviceInfoList(i);
    
                return deviceInformations;
    }

    List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
                ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_PnPEntity");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    devices.Add(new USBDeviceInfo(
                    (string)queryObj["DeviceID"],
                    (string)queryObj["PNPDeviceID"],
                    (string)queryObj["Name"]
                    ));
                }
                    foreach (USBDeviceInfo usbDevice in devices)
                {
                    if (usbDevice.Description != null)
                    {
                        if (usbDevice.Description.Contains("NAME OF Device You are Looking for")) //use your own device's name
                        {
                            int i = usbDevice.Description.IndexOf("COM");
                            char[] arr = usbDevice.Description.ToCharArray();
                            str = "COM" + arr[i + 3];
                            if (arr[i + 4] != ')')
                            {
                                str += arr[i + 4];
                            }
                            break;
                        }
                    }
                }
                mySerialPort = new SerialPort(str);
                

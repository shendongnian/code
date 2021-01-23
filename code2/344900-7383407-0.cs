    var guidComPorts = Guid.Empty;
            UInt32 dwSize;
            IntPtr hDeviceInfo;
            var buffer = new byte[512];
            var providerName = new[] { };
            var spddDeviceInfo = new SpDevinfoData();
            var bStatus = SetupDiClassGuidsFromName("Ports", ref guidComPorts, 1, out dwSize);
            if (bStatus)
            {
                hDeviceInfo = SetupDiGetClassDevs(
                    ref guidComPorts,
                    (IntPtr)null,
                    (IntPtr)null,
                    DigcfPresent | DigcfProfile);
                if (hDeviceInfo.ToInt32() != 0)
                {
    
                    while (true)
                    {
                        spddDeviceInfo.CbSize = Marshal.SizeOf(spddDeviceInfo);// IS IT THIS LINE WORK FOR 64 BIT                        
                        bStatus = SetupDiEnumDeviceInfo(hDeviceInfo, nDevice++, ref spddDeviceInfo);
                        break;
                    }
    
                }
    
    
                return;
            }
    
        }

    private void GetDevices()
    {
        foreach (SharpPcap.LibPcap.LibPcapLiveDevice dev in SharpPcap.LibPcap.LibPcapLiveDeviceList.Instance)
        {
            for (int i = 0; i < dev.Addresses.Count; i++)
            {
                var ip = dev.Addresses[i].Addr.ipAddress;
                if (ip == null)
                    continue;
                iDeviceDropDown.Items.Add(ip.ToString());
            }
        }
    }

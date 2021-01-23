    static void getCurrentNicLifeTime(NetworkInterface adapter)
        {
            IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
           
            UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
            if (uniCast.Count > 0)
            {
                foreach (UnicastIPAddressInformation uni in uniCast)
                {
                    DateTime when;
                    when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressValidLifetime) - TimeSpan.FromSeconds(864000);
                    when = when.ToLocalTime();
                    Console.WriteLine(DateTime.UtcNow.ToLocalTime() - when);
                }
            }
        }

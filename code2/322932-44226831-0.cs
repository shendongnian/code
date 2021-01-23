      public static List<string> GetAllLocalIPv4(NetworkInterfaceType type)
            {
                return NetworkInterface.GetAllNetworkInterfaces()
                    .Where(x => x.NetworkInterfaceType == type && x.OperationalStatus == OperationalStatus.Up)
                    .SelectMany(x => x.GetIPProperties().UnicastAddresses)
                    .Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork).Select(x => x.Address.ToString()).ToList();
            }

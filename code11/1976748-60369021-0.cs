      public static string getMacAddress()
        {
            string macAddress = string.Empty;
            var all = Collections.List(Java.Net.NetworkInterface.NetworkInterfaces);
            foreach (var interfaces in all)
            {
                if (!(interfaces as Java.Net.NetworkInterface).Name.Contains("wlan0")) continue;
                var macBytes = (interfaces as
                Java.Net.NetworkInterface).GetHardwareAddress();
                if (macBytes == null) continue;
                var sb = new System.Text.StringBuilder();
                foreach (var b in macBytes)
                {
                    string convertedByte = string.Empty;
                    convertedByte = (b & 0xFF).ToString("X2") + ":";
                    if (convertedByte.Length == 1)
                    {
                        convertedByte.Insert(0, "0");
                    }
                    sb.Append(convertedByte);
                }
                macAddress = sb.ToString().Remove(sb.Length - 1);
                return macAddress;
            }
            return "02:00:00:00:00:00";
        }

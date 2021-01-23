          [DllImport("iphlpapi.dll", SetLastError = true)]
      public static extern int GetAdaptersInfo(byte[] info, ref uint size);
      /// <summary>
      /// Gets the Mac Address
      /// </summary>
      /// <returns>the mac address or ""</returns>
      public static unsafe string GetMacAddress()
      {
         uint num = 0u;
         GetAdaptersInfo(null, ref num);
         byte[] array = new byte[(int)((UIntPtr)num)];
         int adaptersInfo = GetAdaptersInfo(array, ref num);
         if (adaptersInfo == 0)
         {
            string macAddress = "";
            int macLength = BitConverter.ToInt32(array, 400);
            macAddress = BitConverter.ToString(array, 404, macLength);
            macAddress = macAddress.Replace("-", ":");
            return macAddress;
         }
         else
            return "";
      }

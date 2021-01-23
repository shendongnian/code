    txtMac.text=getFormatMac(GetMacAddress());
    public string GetMacAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
             if (sMacAddress == String.Empty)// solo retorna la mac de la primera tarjeta
             {
                  IPInterfaceProperties properties = adapter.GetIPProperties();
                  sMacAddress = adapter.GetPhysicalAddress().ToString();
              }
        }
        return sMacAddress;
    }
    
    public string getFormatMac(string sMacAddress)
    {
        string MACwithColons = "";
        for (int i = 0; i < macName.Length; i++)
        {
            MACwithColons = MACwithColons + macName.Substring(i, 2) + ":";
            i++;
        }
        MACwithColons = MACwithColons.Substring(0, MACwithColons.Length - 1);
    
        return MACwithColons;
    }

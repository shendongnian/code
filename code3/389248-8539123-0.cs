    string ipAddress = "192.168.1.57";
    string subNetMask = "255.255.0.0";
    string[] ipOctetsStr = ipAddress.Split('.');
    string[] snOctetsStr = subNetMask.Split('.');
       
    if (ipOctetsStr.Length != 4 || snOctetsStr.Length != 4)
    {
       throw new ArgumentException("Invalid input strings.");
    }
    string[] resultOctets = new string[4];
    for (int i = 0; i < 4; i++) 
    {
        byte ipOctet = Convert.ToByte(ipOctetsStr[i]);
        byte snOctet = Convert.ToByte(snOctetsStr[i]);
        resultOctets[i] = (ipOctet & snOctet).ToString();
    }
            
    string resultIP = string.Join(".", resultOctets);

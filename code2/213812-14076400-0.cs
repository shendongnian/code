    INetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
    //for each j you can get the MAC 
    PhysicalAddress address = nics[0].GetPhysicalAddress();
    byte[] bytes = address.GetAddressBytes();
    for(int i = 0; i < bytes.Length; i++) {
        // Display the physical address in hexadecimal. 
        Console.Write("{0}", bytes[i].ToString("X2"));
        // Insert a hyphen after each byte, unless we are at the end of the address. 
        if(i != bytes.Length - 1) {
            Console.Write("-");
        }
    }

    private string GetIPfromNetworkCard(string EthernetCardName)
        {
            string Ret = "";
            foreach (NetworkInterface netif in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netif.Name == EthernetCardName)
                {
                    IPInterfaceProperties properties = netif.GetIPProperties();
                    //foreach (IPAddressInformation unicast in properties.UnicastAddresses)
                    //{
                                                           
                    // Select the first one...
                    Ret = properties.UnicastAddresses[0].Address.ToString();
                    break;
                    
                    //}
                }
            }
            return Ret;
        }

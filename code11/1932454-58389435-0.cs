    public static GatewayClient GetCurGwClient(System.Net.IPAddress gwIP)//string
    {
        return listKateApiObjcts
          .FirstOrDefault(x => x.CurrentGatewayClient.Gateway.IpAddress.ToString() == gwIP.ToString())
         ?.CurrentGatewayClient;
    }

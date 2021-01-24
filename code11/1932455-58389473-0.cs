     public static GatewayClient GetCurGwClient(System.Net.IPAddress gwIP) { 
       return listKateApiObjcts
         .Select(item => item.CurrentGatewayClient) 
         .FirstOrDefault(client => client.Gateway.IpAddress.ToString() == gwIP.ToString());
     }

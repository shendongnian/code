    public struct ClientData
    
    {
       public string descricao;
       public string timer;
    }
   
    [WebMethod]
        public ClientData[] teste()
        {
            ClientData[] Clients = null;
            Clients = new ClientData[30];
            Clients[0].descricao = "oi";
            Clients[0].timer = "legal";
            return Clients;
        }

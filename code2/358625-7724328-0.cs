    [WebMethod] 
    public string DoPing(string ipString, IPAddress ipAdress)
    {
        if(ipString != null)
        {
            DoPing(ipString);
        }
        if(ipAdress != null)
        {
            DoPing(ipAdress);
        }
    }

    public void ExportServerInfo(string s)
    {
        Server server = Newtonsoft.Json.JsonConvert.DeserializeObject<Server>(s);
        
        // Do something with the Server
        System.Diagnostics.Debug.WriteLine(server.Name);
        System.Diagnostics.Debug.WriteLine(server.RamCapacity);
    }

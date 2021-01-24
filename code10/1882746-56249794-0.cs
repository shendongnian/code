    WebClient client = new WebClient();
    string json = 
    client.DownloadString("https://restcountries.eu/rest/v2/all/");
    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
    {
    DataContractJsonSerializer deserializer = new 
    DataContractJsonSerializer(List<RootObject>); //TODO: FIXED
    List<RootObject>obj = (List<RootObject>)deserializer.ReadObject(ms); //TODO: FIXED
    foreach (var name in obj.name)
    {
    comboBox1.Items.Add(obj.name);
    }
    }

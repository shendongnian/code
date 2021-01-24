    public static void Main(string[] args)
    {
        WebClient client = new WebClient();
        string jData = client.DownloadString("https://www.511virginia.org/data/geojson/icons.rwis.geojson");
        var data = JsonConvert.DeserializeObject<Rootobject>(jData);
        var val = data.features.Where(x => x.id == "VAV01" || x.id == "VATLG").ToList();
        Console.ReadLine();
    }

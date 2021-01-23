    using System.Runtime.Serialization.Json;
    DataContractJsonSerializer desc = new DataContractJsonSerializer(typeof(BlogSite));
    string json = "{\"Description\":\"Share knowledge\",\"Name\":\"zahid\"}";
    using (var ms = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(json)))
    {
        BlogSite b = (BlogSite)desc.ReadObject(ms);
        Console.WriteLine(b.Name);
        Console.WriteLine(b.Description);
    }

    WebClient client = new WebClient();
    string json =
    client.DownloadString("https://restcountries.eu/rest/v2/all/");
    dynamic dyn = JsonConvert.DeserializeObject<List<CountryName>>(json);
    foreach (var item in dyn)
    {
      comboBox1.Items.Add(item.name);
    }
    public class CountryName
    {
      public string name { get; set; }    
    }

    JsonTextReader reader = null;
    try
    {
        WebClient webClient = new WebClient();
        JObject result = JObject.Parse(webClient.DownloadString("YOUR URL"));
        reader = new JsonTextReader(new System.IO.StringReader(result.ToString()));
        reader.SupportMultipleContent = true;
    }
    catch(Exception)
    {}
    JsonSerializer serializer = new JsonSerializer();
    MenuInfo menuInfo = serializer.Deserialize<MenuInfo>(reader);

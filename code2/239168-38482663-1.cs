    private HttpContent ConvertToJsonContent(object content)
    {
      string jsonObject = Regex.Unescape(JsonConvert.SerializeObject(content, Newtonsoft.Json.Formatting.Indented));
      return new StringContent(jsonObject, Encoding.UTF8, "application/json");
    }

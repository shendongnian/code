    private HttpContent ConvertToJsonContent(object content)
    {
      string jsonObject = JsonConvert.SerializeObject(content, Newtonsoft.Json.Formatting.Indented);
      return new StringContent(jsonObject, Encoding.UTF8, "application/json");
    }

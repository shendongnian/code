    json = new JArray(
        JArray.Parse(json)
              .SelectTokens("..count")
              .Select(c =>
                  new JObject(
                      new JProperty("types",
                          new JArray(
                              c.Ancestors()
                               .OfType<JObject>()
                               .Select(o => (string)o["type"])
                               .Reverse()
                          )
                      ),
                      new JProperty("count", c)
                  )
              )
    ).ToString();

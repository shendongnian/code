    json = new JArray(
        JArray.Parse(json)
              .SelectTokens("..count")
              .Select(c =>
                  new JObject(
                      new JProperty("types",
                          new JArray(
                              c.Ancestors()
                               .OfType<JObject>()
                               .Reverse()
                               .Select(o => (string)o["type"])
                          )
                      ),
                      new JProperty("count", c)
                  )
              )
    ).ToString();

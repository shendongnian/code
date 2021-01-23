    public static void AddAttributes(this HtmlLink thisLink, IDictionary<string, string> attributes)
    {
      foreach(var attribute in attributes.Keys)
      {
        thisLink.Attributes.Add(attribute.Key, attribute.Value);
      }
    }

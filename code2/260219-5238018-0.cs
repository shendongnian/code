    public static string GetElementValue(this XElement parent, string elementName) {
      if (parent == null) { 
        return string.Empty;
      }
      var element = parent.Element(elementName);
      if (element == null || element.Value == null) {
        return string.Empty;
      }
      return element.Value;
    }

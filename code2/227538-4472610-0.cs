    public static class XElementExtension
    {
       public static string GetValue(this XElement input)
       {
          if (input == null)
            return null;
          return input.Value as T;
       }
    
       public static XElement GetSubElement(this XElement element, string id)
       {
          if (element == null)
            return null;
          return element.Element(id);
       }
    }

    internal static class Utils
    {
      internal static List<HtmlElement> getElementsByTagAndClassName(this HtmlDocument doc, string tag = "", string className = "")
      {
          List<HtmlElement> lst = new List<HtmlElement>();
          bool empty_tag = String.IsNullOrEmpty(tag);
          bool empty_cn = String.IsNullOrEmpty(className);
          if (empty_tag && empty_cn) return lst;
          HtmlElementCollection elmts = empty_tag ? doc.All : doc.GetElementsByTagName(tag);
          if (empty_cn)
          {
             lst.AddRange(elmts.Cast<HtmlElement>());
             return lst;
          }
          for (int i = 0; i < elmts.Count; i++)
          {
             if (elmts[i].GetAttribute("className") == className)
             {
                lst.Add(elmts[i]);
             }
          }
          return lst;
       }
    }

    string GetJsonStringFromItem(ScopeType scope) {
      var localDict = new Dictionary<string, object>();
      var childrens = scope.Children.Where(x => x.Attributes.Any(a => a.Name == "itemprop"));
      foreach (var child in childrens)
      {
          var propValue;
          if (child.GetAttribute("itemscope"))
          {
              // this is the recursion: do the same with the nested scope
              propValue = GetJsonStringFromItem(child);
          } else {
              propValue = child.TextContent;
          }
          string prop = child.GetAttribute("itemprop");
          if (!localDict.ContainsKey(prop))
          {
              localDict.Add(prop, child.TextContent);
          }
      }
      return JsonConvert.SerializeObject(localDict, Newtonsoft.Json.Formatting.Indented);
    }

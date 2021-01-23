    var counts = clearingMessagesDoc
        .Elements("ClearingMessages")
        .Elements("FIXML")
        .Descendants() // checks ALL elements in the hierarchy
        .GroupBy(e => e.Name.ToString())
        .ToDictionary(
            g => g.Key,
            g => g.SelectMany(e => e.Attributes())
                  .GroupBy(attr => new { Name = attr.Name.ToString(), Value = attr.Value.Trim() })
                  .OrderBy(attrg => attrg.Key.Name)
                  .ThenBy(attrg => attrg.Key.Value)
                  .ToDictionary(
                      attrg => String.Format("{0}=\"{1}\"", attrg.Key.Name, attrg.Key.Value),
                      attrg => attrg.Count()));

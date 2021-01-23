    Dictionary<string, List<SubChild>> dict = doc.Root.Elements().ToDictionary(
        e => e.Name.ToString(),
        e => e.Elements("sub_child")
              .Select(s => new SubChild
                           {
                               a1 = s.Attribute("attr1").Value,
                               a2 = s.Attribute("attr2").Value,
                           }).ToList());
    dict["child_1"][0] // get the first subchild of "child_1"

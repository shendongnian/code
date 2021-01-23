    string result = "";
                    var childType = themes.Descendants("theme")
                                                   .Where(x => x.Attribute("name").Value == theme)
                                                   .Where(x => x.Descendants("node").First().Attribute("type").Value == parentType)
                                                   .Select(x => x.Descendants("node").First().Descendants().First().Attribute("type").Value);
    
                    foreach (var t in childType) {
                        result += t;
                    }
                    return result;

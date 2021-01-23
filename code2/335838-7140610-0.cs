    var res = (from term in doc.Root.Elements("Record").Elements("Term")
               let parent = term.Parent
               select new
                      {
                          LanguageCode = term.Attribute("languageCode").Value,
                          ConceptNumber = Convert.ToInt32(term.Attribute("conceptNumber").Value),
                          IsHidden = Convert.ToBoolean(term.Attribute("hidden").Value),
                          Label = term.Value,
                          InputDate = parent.Element("InputDate").Value,
                          LastUpdate = parent.Element("LastUpdated").Value
                      }).ToList();

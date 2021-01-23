    var results = doc.Elements("Record")
                     .Select( x => new 
                      {
                        Terms = x.Elements("Term"),
                        InputDate = DateTime.Parse(x.Element("InputDate").Value),
                        LastUpdate = DateTime.Parse(x.Element("LastUpdate").Value)
                      }) 
                     .SelectMany(x => x.Terms, (record,term) => new
                     {
                        LanguageCode = term.Attribute("languageCode").Value,
                        ..
                        InputDate = record.InputDate,
                        LastUpdate = record.LastUpdate
                     });

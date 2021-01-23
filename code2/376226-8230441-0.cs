                result = (from d in XDocument.Parse(data.OuterXML).Root.Descendants()
                          let isString = true //Replace true with your logic to determine if it is a string.
                          let isInt = false   //Replace false with your logic to determine if it is an integer.
                          let stringValue = isString ? (DataField)new DataField<string>
                          {
                              Name = d.Name.ToString(),
                              Value = d.Value
                          } : null
                          let intValue = isInt ? (DataField)new DataField<int>
                          {
                              Name = d.Name.ToString(),
                              Value = Int32.Parse(d.Value)
                          } : null
                          select stringValue ?? intValue).ToList();

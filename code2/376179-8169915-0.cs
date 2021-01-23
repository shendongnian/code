     public static DataFields ConvertXML(XmlDocument data)
            {
                DataFields result = (DataFields)(from d in XDocument.Parse(data.OuterXml).Elements()
                                      select new DataField<string>
                                      {
                                          Name = d.Name.ToString(),
                                          Value = d.Value
                                      }).Cast<DataField>();
                return result;
            }

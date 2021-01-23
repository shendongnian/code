    List<Parameter> tempList = (from param in x.Descendants("Parameter")
                                  select new Parameter
                                  {
                                      Name = param.Attribute("Name").Value,
                                      Value = param.Attribute("Value").Value,
                                      Run = Convert.ToBoolean(param.Attribute("Run").Value),
                                      Number = (int?) param.Attribute("Number"),
                                      Directory = param.Attribute("Directory").Value,
                                      Filename = (string)param.Attribute("Filename") ?? "None",
                                      Source = (string)param.Attribute("Source") ?? "None",
                                      FileTypes = (string)param.Attribute("FileTypes") ?? "None"
                                  }).ToList();

    cols.Elements().Where(
                    e =>
                        {
                            var attribute = e.Attribute("isactive");
                            return attribute != null &&
                                   attribute.Value.ToString().Equals("true", StringComparison.CurrentCultureIgnoreCase);
                        })
                    .ToDictionary(e => e.Name.ToString(),
                                  e => Convert.ToInt32(e.Attribute("sequence").Value.ToString()));

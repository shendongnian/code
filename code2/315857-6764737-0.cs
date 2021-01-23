    foreach (Type mappingClass in mappingClasses)
                                      {
                                          if (!mappingClass.Namespace.Contains("Adapter.Common") &&
                                              !mappingClass.Namespace.Contains("OracleMapping"))
                                          {
                                              m.FluentMappings.Add(mappingClass);
                                          }
                                      }

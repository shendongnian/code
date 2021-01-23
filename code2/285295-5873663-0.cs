    fc.Property.ToList().ForEach(fp =>
                          {
                              var prop = nc.GetType().GetProperty(propName);
                              if (prop != null)
                                prop.SetValue(nc, fp.Value);
                          });

    var dbSets = typeof(AuthContext).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                dbSets.Where(pi =>
                                pi.PropertyType.IsGenericType &&
                                pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)).ToList()
                      .ForEach(pi =>
                          {
                              typeof(DbSet<>)
                                  .MakeGenericType(pi.PropertyType.GetGenericArguments()[0])
                                  .GetMethod("Clear")
                                  .Invoke(pi.GetValue(currentContext, null), null);
                          }
                          );

    //Check that a table exists
                if (sqlScript.ToLower().Contains(string.Format(CREATETABLELOOKUP, tableName.ToLower())))
                {
                    
                    //indexes
                    var indexAttrib = typeof (IndexAttribute);
                    properties = type.GetProperties().Where(prop => Attribute.IsDefined(prop, indexAttrib));
                    foreach (var property in properties)
                    {
                        var attributes = property.GetCustomAttributes(indexAttrib, true).ToList();
                        foreach (IndexAttribute index in attributes)
                        {
                            var indexName = string.Format(INDEXNAMEFORMAT, tableName, property.Name,
                                                          attributes.Count > 1
                                                              ? UNDERSCORE + (attributes.IndexOf(index) + 1)
                                                              : string.Empty);
                            try
                            {
                                context.ObjectContext.ExecuteStoreCommand(
                                    string.Format(INDEX_STRING, indexName,
                                                  tableName,
                                                  property.Name,
                                                  index.IsUnique ? UNIQUE : string.Empty,
                                                  index.IsClustered ? CLUSTERED : NONCLUSTERED,
                                                  index.SortOrder == SortOrder.Ascending ? ASC : DESC));
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

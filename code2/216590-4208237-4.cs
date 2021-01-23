                    new IndexDefinition<Item, Item>()
                    {
                        Map = docs => from doc in docs
                                      select new
                                      {
                                          Tags = doc.Tags
                                      },
                        Indexes = {{ x => x.Tags, FieldIndexing.Analyzed }}
                    }.ToIndexDefinition(store.Conventions));

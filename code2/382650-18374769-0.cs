    ConventionModelMapper mapper = new ConventionModelMapper();
    
    //...other mappings
    
    mapper.Class<Entity>(map => map.Version(e => e.Revision, m =>
                    {
                        m.Generated(VersionGeneration.Always);
                        m.UnsavedValue(null);
                        m.Type(new BinaryBlobType());
                        m.Column(c =>
                            {
                                c.SqlType("timestamp");
                                c.NotNullable(false);
                            });
                    }));

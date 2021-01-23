    ObjectFactory.Configure(item =>
                {
                    item.Scan(
                        x =>
                        {
                            x.AssembliesFromPath("c:\wheremyassemblyis.dll");
                            x.With(new MyRegistration());
                        });
                });

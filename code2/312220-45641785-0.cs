                BsonClassMap.RegisterClassMap<Inner>(cm =>
                {
                    cm.AutoMap();
                    cm.UnmapProperty(c => c.Id);
                    cm.MapMember(c => c.Id)
                        .SetElementName()
                        .SetOrder(0) //specific to your needs
                        .SetIsRequired(true); // again specific to your needs
                });

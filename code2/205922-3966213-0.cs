    x.For<ICacheStorage>().ConditionallyUse(c =>
                                                                    {
                                                                        c.If(t => t.ParentType == typeof(Test) ||
                                                                            t.ParentType == typeof(Test2))
                                                                            .ThenIt
                                                                            .Is.ConstructedBy(
                                                                                by => new HttpContextCacheAdapter());
                                                                        c.TheDefault.Is.ConstructedBy(
                                                                                by => new NullObjectCache());
                                                                    });

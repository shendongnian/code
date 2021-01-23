    builder.Register<ListViewModel>()
           .As<IHasCommonServices>()
           .OnActivated(c => 
                        {
                            c.Instance.Session = c.Context.Resolve<ISession>();
                            c.Instance.EventPublisher = c.Context.Resolve<IEventPublisher>();
                        });

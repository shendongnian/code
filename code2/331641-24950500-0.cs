    container.AddFacility<StartableFacility>();
    container.Register(Component.For<ISubscriber<TagsProcessed>>()
                                        .ImplementedBy<TagsProcessedListener>()
                                        .OnCreate((kernel, instance) => eventAggregator.Subscribe(instance)).Start());
 

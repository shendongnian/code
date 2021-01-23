    container.Register(Component.For<IComponent>()
                                .ImplementedBy<AComponent>()
                                .ServiceOverrides(
                                    ServiceOverride.ForKey("writer").Eq("AWriter"));
    container.Register(Component.For<IComponent>()
                                .ImplementedBy<BComponent>()
                                .ServiceOverrides(
                                    ServiceOverride.ForKey("writer").Eq("BWriter"));

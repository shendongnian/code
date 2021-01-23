    WindsorContainer BuildContainer()
    {
        var container = new WindsorContainer();
        
		    container.Register(Component.For<Controller>().Named("ControllerWithViewA")
														  .ImplementedBy<Controller>()
														  .DependsOn(Property.ForKey(typeof(IView))
                                                          .Is(typeof(ConcreteViewA)));
            container.Register(Component.For<Controller>().Named("ControllerWithViewB")
														 .ImplementedBy<Controller>()
														 .DependsOn(Property.ForKey(typeof(IView))
														 .Is(typeof(ConcreteViewB)));
        return container;
    }

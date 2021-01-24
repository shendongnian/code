    [BeforeFeature]
        public static void RegisterConcreteType(IObjectContainer objectContainer)
        {
            var myClass = new class();
            objectContainer.RegisterInstanceAs<Iinterface>(myClass);
        }

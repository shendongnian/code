    protected override void Configure()
        {
            container = new SimpleContainer();
            
            container.Instance(container);
            container
                .Singleton<IMyObjectService, MyObjectService>();
            //Register all ViewModel classes            
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModleType => container.RegisterPerRequest(
                    viewModleType, viewModleType.ToString(), viewModleType));
        }

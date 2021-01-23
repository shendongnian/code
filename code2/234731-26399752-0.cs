    public class IoC
    {
        private WindsorContainer _container;
        private IoC()
        {
             _container = new WindsorContainer();
        }
    
        public static void RegisterFromAssembly(Assembly assembly, string classEndsWith, LifeTime lifeTime)
        {
            var lifestyle = ConvertLifeStyleType(lifeTime);
            _container.Register(AllTypes.FromAssembly(assembly)
                      .Where(type => type.Name.EndsWith(classEndsWith))
                      .WithService.AllInterfaces()
                      .Configure(c => c.LifeStyle.Is(lifestyle))
                      .WithService.FirstInterface());
        }
    }

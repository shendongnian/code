    public class MyBaseFactory : IMyBaseFactory
    {
        private Autofac.IContainer container;
        public MyBase CreateMyBaseForScenarioA()
        {
            return container.Resolve<DerivedA>();
        }
        public MyBase CreateMyBaseForScenarioB()
        {
            return container.Resolve<DerivedB>();
        }
    }

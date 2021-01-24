    using Castle.Windsor;
    using System;
    using Component = Castle.MicroKernel.Registration.Component;
    namespace StackoverflowSample
    {
      internal class Program
      {
        //A global variable to define my container.
        protected static WindsorContainer _container;
        //Resolver to map my interfaces with my implementations
        //that should be called in the main method of the application.
        private static void Resolver()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<IFood>().ImplementedBy<FrenchCuisine>());
            _container.Register(Component.For<IFood>().ImplementedBy<ComidaBrasileira>());
            _container.Register(
                Component.For<ITranslate>().ImplementedBy<FrenchTranslator>().DependsOn(new FrenchCuisine()));
        }
        private static void Main(string[] args)
        {
            Resolver();
            var menu = _container.Resolve<ITranslate>();
            Console.WriteLine(menu.GetMenu());
            Console.ReadKey();
        }
      }
    }

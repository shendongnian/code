    using System;
    using Unity;
    class Program
    {
        static void Main(string[] args)
        {
            // Composition Root
            var container = new UnityContainer();
            container.RegisterFactory<IMetric>(c => BuildMetric());
            container.RegisterType<ILoader, Loader>();
            container.RegisterType<ISomeClassThatDependsOnLoader, SomeClassThatDependsOnLoader>();
            // Application (runtime)
            var kk = container.Resolve<ISomeClassThatDependsOnLoader>();
            kk.DoSomething();  //Loader gets instantiated in here..
        }
        public static IMetric BuildMetric()
        {
            return new Metric();
        }
    }
    public interface ILoader
    {
        IMetric Metric { get; set; } // Property Injection
    }
    public class Loader : ILoader
    {
        [Dependency]
        public IMetric Metric { get; set; }
    }
    public interface IMetric
    {
    }
    public class Metric : IMetric
    {
    }
    public interface ISomeClassThatDependsOnLoader
    {
        void DoSomething();
    }
    public class SomeClassThatDependsOnLoader : ISomeClassThatDependsOnLoader
    {
        private readonly ILoader loader;
        public SomeClassThatDependsOnLoader(ILoader loader) // Constructor Injection
        {
            this.loader = loader ?? throw new ArgumentNullException(nameof(loader));
        }
        public void DoSomething()
        {
            // Do something with this.loader.Metric...
        }
    }

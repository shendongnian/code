    using System;
    using Unity;
    class Program
    {
        static void Main(string[] args)
        {
            // Composition Root
            var container = new UnityContainer();
            container.RegisterType<IMetric, Metric>();
            container.RegisterType<IApplication, Application>();
            // Application (runtime)
            // Note that in a console application, you generally only call 
            // container.Resolve() once followed by a method to set things 
            // in motion. The type you resolve here should represent the
            // ENTIRE console application, and you would typically pass 
            // the args (if used) through to that class to process them. 
            // No business logic should go here, only code to read config files,
            // register types, and set the application in motion.
            var app = container.Resolve<IApplication>(); // Application and Metric get instantiated here...
            app.Run(args);
        }
    }
    public interface IMetric
    { }
    public class Metric : IMetric
    { }
    public interface IApplication
    {
        void Run(string[] args);
    }
    public class Application : IApplication
    {
        private readonly IMetric metric;
        public Application(IMetric metric) // Constructor Injection
        {
            this.metric = metric ?? throw new ArgumentNullException(nameof(metric));
        }
        public void Run(string[] args)
        {
            // Do something with this.metric...
        }
    }

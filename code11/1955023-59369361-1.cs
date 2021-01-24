    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApp
    {
        public class Program
        {
            public static void Main (string[] args)
            {
                Assembly assembly = typeof (Program).Assembly; // use current assembly...
    
                var types = assembly.GetExportedTypes() // public types only
                                    .Where (type => type.GetInterfaces().Contains (typeof (IProcessor))) // interface must be implemented
                                    .Where (type => type.Name.EndsWith ("Processor")) // and maybe use some naming convention?
                                    .ToList();
    
                //string name = args[0];
                string name = "Parrot";
    
                Type parrotType = types.Where (x => x.Name.StartsWith (name)).FirstOrDefault();
    
                if (parrotType != null)
                {
                    // it will work only when we implement parameterless constructor for this type
                    IProcessor parrotInstance = (IProcessor) Activator.CreateInstance (parrotType);
                    parrotInstance.Process();
                }
            }
        }
    
        public interface IProcessor
        {
            void Process();
        }
    
        public class SnakeProcessor : IProcessor
        {
            public void Process()
            {
            }
        }
    
        public class ParrotProcessor : IProcessor
        {
            public void Process()
            {
                Console.WriteLine ("Parrot Process");
            }
        }
    }
    

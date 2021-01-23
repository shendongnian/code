    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using Classes;
    namespace Interfaces
    {
        public interface IDoWork
        {
            string Name { get; set; }
            string Process();
        }
    }
    namespace Classes
    {
        public static class FactoryClass
        {
            public static T Create<T>(string s) where T : class
            {
                var className = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof (T).IsAssignableFrom(t))
                    .Select(x => x.FullName)
                    .Where(y => y.Contains(s))
                    .FirstOrDefault();
                // we could check for null here etc before hitting the activator ...
                var newUnit = (T)Activator.CreateInstance(Type.GetType(className));
                return (T)newUnit;
            }
        }
        public class DoWorkType1 : IDoWork
        {
            public string Name{ get; set; }
            public string Process()
            {
                return "It's me - Mr DoWorkType1";
            }
        }
        public class DoWorkType2 : IDoWork
        {
            public string Name { get; set; }
            public string Process()
            {
                return "My turn - Ms DoWorkType2";
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            
            var newWork = FactoryClass.Create<IDoWork>("DoWorkType1");
            Console.WriteLine(newWork.Process());
            newWork = FactoryClass.Create<IDoWork>("DoWorkType2");
            Console.WriteLine(newWork.Process());
            Console.Read();
        }
    }

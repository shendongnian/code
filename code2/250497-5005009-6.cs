    using System;
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
        public static class FactoryClass<T> where T : class
        {
            public static T Create(string s)
            {
                // assumes factory class and implemented class are in same namespace
                var currentNamespace = System.Reflection.MethodBase
                                            .GetCurrentMethod()
                                            .DeclaringType.Namespace;
                var className = string.Format("{0}.{1}", currentNamespace, s);
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
            
            var newWork = FactoryClass<IDoWork>.Create("DoWorkType1");
            Console.WriteLine(newWork.Process());
            newWork = FactoryClass<IDoWork>.Create("DoWorkType2");
            Console.WriteLine(newWork.Process());
            Console.Read();
        }
    }

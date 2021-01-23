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
        public class FactoryClass<T> where T : class
        {
            public T Create(string s)
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
            string IDoWork.Name{ get; set; }
            string IDoWork.Process()
            {
                return "It's me - Mr DoWorkType1";
            }
        }
        public class DoWorkType2 : IDoWork
        {
            string IDoWork.Name { get; set; }
            string IDoWork.Process()
            {
                return "My turn - Ms DoWorkType2";
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var factoryClass = new FactoryClass<IDoWork>();
            IDoWork newWork = factoryClass.Create("DoWorkType1");
            Console.WriteLine(newWork.Process());
            newWork = factoryClass.Create("DoWorkType2");
            Console.WriteLine(newWork.Process());
            Console.Read();
        }
    }

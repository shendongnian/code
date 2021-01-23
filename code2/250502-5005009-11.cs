    using System;
    using System.Collections.Generic;
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
        public class FactoryClass
        {
            private static readonly IDictionary<string, Type> ClassMembers 
                = new Dictionary<string, Type>();
            public static T Create<T>(string s) where T : class
            {
                // if we have 'cached' the type, then use it
                if (ClassMembers.ContainsKey(s))
                {
                    return (T)Activator.CreateInstance(ClassMembers[s]);
                }
                // determine the concrete type
                var concreteClass = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(T).IsAssignableFrom(t)
                        && t.FullName.ToLower().Contains(s.ToLower()))
                    .FirstOrDefault();
                // if we have a match - give it a ping...
                if (concreteClass != null)
                {
                    var newUnit = (T) Activator.CreateInstance(concreteClass);
                    ClassMembers.Add(s, concreteClass);
                    return (T) newUnit;
                }
                // for the sake of the example - return null for now
                return null;
            }
        }
        public class DoWorkType1 : IDoWork
        {
            public string Name { get; set; }
            public bool isNew = true;
            public string Process()
            {
                isNew = false;
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
            // repeat with DoWorkType1 just to show it coming from dictionary
            newWork = FactoryClass.Create<IDoWork>("DoWorkType1");
            Console.WriteLine(newWork.Process());
            Console.Read();
        }
    }

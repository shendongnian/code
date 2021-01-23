    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    class Test<T>
    {
        public List<int> ListInt32 { get; set; }
        public List<T> ListT { get; set; }
        public string Other { get; set; }
        public Action<string> OtherGeneric { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var query = from prop in typeof(Test<string>).GetProperties()
                        let propType = prop.PropertyType
                        where propType.IsGenericType &&
                              propType.GetGenericTypeDefinition() == typeof(List<>)
                        select prop.Name;
            
            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
        }
    }

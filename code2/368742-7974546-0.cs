    using System;
    using System.Reflection;
    namespace BaseTypetest
    {
        class Program
        {
            static void Main(string[] args)
            {
                BaseClass2 class2 = new BaseClass2();
                Console.WriteLine(class2.Value.ToString());
                Type baseClass = class2.GetType().BaseType;
                Console.WriteLine(baseClass.FullName);
                PropertyInfo info = baseClass.GetProperty("Value");
                if (info != null)
                {
                    Console.WriteLine(info.GetValue(class2, null).ToString());
                }
                Console.ReadKey();
            }
        }
    
        public class BaseClass1 : Object
        {
            public BaseClass1()
            {
                this.Value = 1;
            }
    
            public int Value { get; set; }
        }
    
        public class BaseClass2 : BaseClass1
        {
            public BaseClass2()
            {
                this.Value = 2;
            }
            public new int Value { get; set; }
        }
    }

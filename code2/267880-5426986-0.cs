    using System;
    using System.Linq;
    namespace ConsoleApplication1
    {
        static class Program
        {
            private static void SetStaticProperty(string className, string propName, string varx)
            {
                //This sucks, I couldnt find the namespace with easily through reflection :(
                string NAMESPACE = "ConsoleApplication1";
                Type t = Type.GetType(NAMESPACE + "." + className);
                t.GetProperties().Where(p => p.Name == propName).First().SetValue(null, varx, null);
            }
            public static void updateVarx(string className, string varx)
            {
                SetStaticProperty(className, "A", varx);
            }
            public static void updateVary(string className, string vary)
            {
                SetStaticProperty(className, "B", vary);
            }
            static void Main(string[] args)
            {
                updateVarx("Foo", "FooAstring");
                updateVarx("Bar", "BarAstring");
                updateVarx("Yod", "YodAstring");
                updateVary("Foo", "FooBstring");
                updateVary("Bar", "BarBstring");
                updateVary("Yod", "YodBstring");
                Console.WriteLine(Foo.A);
                Console.WriteLine(Foo.B);
                Console.WriteLine(Bar.A);
                Console.WriteLine(Bar.B);
                Console.WriteLine(Yod.A);
                Console.WriteLine(Yod.B);
                Console.ReadLine();
            }
        }
        class Foo
        {
            public static string A { get; set; }
            public static string B { get; set; }
            public static string C { get; set; }
        }
        class Bar
        {
            public static string A { get; set; }
            public static string B { get; set; }
            public static string C { get; set; }
        }
        class Yod
        {
            public static string A { get; set; }
            public static string B { get; set; }
            public static string C { get; set; }
        }
    }

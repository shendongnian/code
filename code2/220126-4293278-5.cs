    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                _test = "Test";
                Console.WriteLine(Test_2);
                Console.WriteLine(Reflector_Test_2);
                Console.ReadLine();
            }
    
            public static string _test;
            public static string _setting;
    
            public static string Test_1
            {
                get { return _test ?? (_setting ?? "default"); }
            }
    
            public static string Test_2
            {
                get { return _test ?? (_test = (_setting ?? "default")); }
            }
    
            public static string Reflector_Test_2
            {
                get
                {
                    if (_test == null)
                    {
                        string text1 = _test;
                    }
                    return (_test = _setting ?? "default");
                }
            }
        }
    }

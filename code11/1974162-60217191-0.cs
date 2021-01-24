    using System;
    
    namespace GenericInOut {
    
        class Test<In, Out> {
            public Out Afunc(In x) {
                return default;
                }
            }
    
        class Program {
            static void Main(string[] args) {
                var t = new Test<int, string>();
                Console.WriteLine($"output is default for string {t.Afunc(3)}");
                }
            }
        }

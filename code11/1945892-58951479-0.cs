    namespace FooApp {
        
        using System.IO;
        using System.Linq;
    
        class MyFoo {
    
            public static void Main(string[] args) {
    
                foreach (var dir in args.Where(a => !string.IsNullOrEmpty(a) && Directory.Exists(a))) {
                    // Valid directory. Do as you please
                }
    
            }
    
        }
    }

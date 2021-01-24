    public static class Example
    {
        private static int value1 = 5;
        public static int Value1 { 
            get {
                Console.WriteLine("Getting Value")
                return value1;
            }
            set {
                Console.WriteLine("Setting Value")
                value1 = value;
            }
        }
    }
---
    // prints "Getting Value"
    // prints "5"
    Console.WriteLine(Example.Value1) 
    
    // prints "Setting Value"
    Example.Value1 = 10;
    // prints "Getting Value"
    // prints "10"
    Console.WriteLine(Example.Value1) 

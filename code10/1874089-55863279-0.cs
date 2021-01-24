    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            InvokeFunc("Double");
            InvokeFunc("Quadruple");
            InvokeFunc("AddOne");
        }
        
        static void InvokeFunc(string name)
        {
            // Note that in our case they're all private static methods. You'd
            // need to adjust the binding flags if that's not the case. If you
            // need to worry about multiple overloads, that makes it harder too.
            MethodInfo method = typeof(Test)
                .GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
            // TODO: Validate that you've got a method
            var func = (Func<int, int>) Delegate.CreateDelegate(
                typeof(Func<int, int>), // Delegate type to create                                                            
                null, // Target of method call; null because ours are static
                method); // Method to create a delegate for
            var result = func(10);
            Console.WriteLine($"{name}(10) => {result}");
        }
        
        static int Double(int x) => x * 2;
        static int Quadruple(int x) => x * 4;
        static int AddOne(int x) => x + 1;
    }

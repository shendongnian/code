    using System;
    using System.Collections;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            Action<string> a = x => Console.WriteLine("First " + x);
            Action<string> b = y => Console.WriteLine("Second " + y);
            
            Action<string> c = a + b;
            
            foreach (var field in typeof(MulticastDelegate).GetFields
                     (BindingFlags.NonPublic | BindingFlags.Instance))
            {
                object value = field.GetValue(c);
                Console.WriteLine("{0}: {1}", field.Name, value);
                if (value != null && value.GetType().IsArray)
                {
                    foreach (var subvalue in (IEnumerable)value)
                    {
                        Console.WriteLine("  - " + subvalue);
                    }
                }
            }
        }
    }

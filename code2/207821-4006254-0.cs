    using System;
    
    public class InputMethodDemoTwo
    {
        public static void Main()
        {
    
            int first, second;
    
            InputMethod(out first, out second);
            Console.WriteLine("After InputMethod first is {0}", first);
            Console.WriteLine("and second is {0}", second);
            Console.ReadLine();
        }
    
        public static void InputMethod(out int first, out int second)
        //Data type was missing here
        {
            first = DataEntry("first");
            second = DataEntry("second");
        }
    
        public static int DataEntry(string method)
        //Parameter to DataEntry should be string
        {
            int result = 0;
            if (method.Equals("first"))
            {
                Console.Write("Enter first integer ");
                Int32.TryParse(Console.ReadLine(), out result);
    
            }
            else if (method.Equals("second"))
            {
                Console.Write("Enter second integer ");
                Int32.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
    }

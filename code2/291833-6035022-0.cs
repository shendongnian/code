    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertExact(2.0, typeof(int)));
            Console.WriteLine(ConvertExact(2.5, typeof(int)));
        }
        
        static object ConvertExact(object convertFromValue, Type convertToType)
        {
            object candidate = Convert.ChangeType(convertFromValue,
                                                  convertToType);
            object reverse =  Convert.ChangeType(candidate,
                                                 convertFromValue.GetType());
            
            if (!convertFromValue.Equals(reverse))
            {
                throw new InvalidCastException();
            }
            return candidate;
        }
    }

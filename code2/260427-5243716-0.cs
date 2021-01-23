    using System;
    
    class Test
    {
        delegate void Callback(object o);
        
        static void Main()
        {
            Callback callback = ShowType<int>;
            callback(10);
        }
        
        static void ShowType<T>(object value)
        {
            Console.WriteLine("Value = " + value);
            Console.WriteLine("typeof(T) = " + typeof(T));
            Console.WriteLine("value.GetType() = " + value.GetType());
        }
    }

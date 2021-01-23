    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class Utils
    {
        public static bool IsAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> items;
            //items = null;
            //items = new String[0];
            items = new String[] { "foo", "bar", "baz" };
            /*** Example Starts Here ***/
            if (items.IsAny())
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No items.");
            }
        }
    }

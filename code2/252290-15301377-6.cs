    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> items;
            //items = null;
            //items = new String[0];
            items = new String[] { "foo", "bar", "baz" };
            /*** Example Starts Here ***/
            bool isEmpty = true;
            if (items != null)
            {
                foreach (var item in items)
                {
                    isEmpty = false;
                    Console.WriteLine(item);
                }
            }
            if (isEmpty)
            {
                Console.WriteLine("No items.");
            }
        }
    }

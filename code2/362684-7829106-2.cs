    using System.Dynamic;
    using System.Collections.Generic;
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            dynamic x = new ExpandoObject();
            x.Data ="test";
            x.Arr = new [] { "test1","test2"};
            x.Lst = new List<string> { "aap", "noot", "mies" };
            Console.WriteLine(string.Join(", ", x.Arr));
            Console.WriteLine(string.Join(", ", x.Lst));
        }
    }

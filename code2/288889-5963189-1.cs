    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> first = new Dictionary<string, string>()
            {
                {"1", "One"},
                {"2", "Two"},
                {"3", "Three"},
                {"4", "Four"},
                {"5", "Five"},
                {"6", "Six"},
                {"7", "Seven"},
                {"8", "Eight"},
                {"9", "Nine"},
                {"0", "Zero"}
            };
            Dictionary<string, string> second = new Dictionary<string, string>();
            foreach (string key in first.Keys)
            {
                second.Add(key, first[key]);
            }
            first["1"] = "newone";
            Console.WriteLine(second["1"]);
        }
    }

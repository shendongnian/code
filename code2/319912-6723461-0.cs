    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class WordList
    {
        static List<List<string>> _WordList; // Static List instance
    
        static WordList()
        {
            _WordList = new List<List<string>>();
        }
    
        public static void Record(List<string> Words)
        {
            _WordList.Add(Words);
        }
    
        public static void Print()
        {
            foreach (var item in _WordList)
            {
                Console.WriteLine("-----");
                Console.WriteLine(string.Join(",", item.ToArray()));
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            WordList.Record(new[] { "Foo", "bar" }.ToList());
            WordList.Record(new[] { "Not", "Foo", "bar" }.ToList());
    
            WordList.Print();
        }
    }

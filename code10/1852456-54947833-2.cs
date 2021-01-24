    using System;
    using System.Linq;
    public enum foo
    {
        unknown = 0,
        bar = 42,
        baz
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enum.GetName  : '{Enum.GetName(typeof(foo), 42)}'");
            var getnames = Enum.GetNames(typeof(foo));
            string names = string.Join(", ", getnames);
            Console.WriteLine($"Enum.GetNames : '{names}'");
            var getValues = Enum.GetValues(typeof(foo)); ;
            var values = string.Join(", ", from v in getValues.Cast<int>() select v.ToString());
            Console.WriteLine($"Enum.GetValues: '{values}'");
            foo caseSensitiveUnknown = (foo)Enum.Parse(typeof(foo), nameof(foo.unknown));
            Console.WriteLine($"Enum.Parse 1:   '{caseSensitiveUnknown}'");
            foo ignoreCaseUnknown = (foo)Enum.Parse(typeof(foo), "UnKnoWn", true);
            Console.WriteLine($"Enum.Parse 2:   '{ignoreCaseUnknown}'");
        }
    }

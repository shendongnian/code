csharp
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace StackOverflow
{
    public class MyObject : Entity
    {
        public List<Luggage> Luggages { get; set; }
    }
    public class Luggage
    {
        public float MaxWeight { get; set; }
        public LuggageType Type { get; set; }
    }
    public enum LuggageType
    {
        One = 1,
        Two = 2,
        Three = 3
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("test", "localhost");
            (new MyObject
            {
                Luggages = new List<Luggage>
                {
                    new Luggage
                    {
                        MaxWeight = 12.345f,
                        Type = LuggageType.Three
                    },
                    new Luggage
                    {
                        MaxWeight = 12.345f,
                        Type = LuggageType.Two
                    }
                }
            }).Save();
            var enumValues = Enum.GetValues(typeof(LuggageType)).Cast<LuggageType>();
            var result = DB.Queryable<MyObject>()
                           .Where(o => o.Luggages.Any(l => enumValues.Contains(l.Type)))
                           .ToList();
        }
    }
}

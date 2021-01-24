    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Linq;
    namespace StackOverFlow
    {
        public class MyModel : Entity
        {
            public string[] Attributes { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test");
                new[] {
                    new MyModel{
                        Attributes = new[]{ "word1", "word2", "word3" }
                    },
                    new MyModel{
                        Attributes = new[]{ "word2", "word3", "word1" }
                    },
                    new MyModel{
                        Attributes = new[]{ "word3", "word1", "word4" }
                    }
                }
                .Save();
                var wantedAttributes = new[] { "word1", "word2" };
                var result = DB.Queryable<MyModel>()
                               .Where(m => wantedAttributes.All(a => m.Attributes.Contains(a)))
                               .ToList();
            }
        }
    }

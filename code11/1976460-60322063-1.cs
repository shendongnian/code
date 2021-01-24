    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackOverFlow
    {
        public class Ntity : Entity
        {
            public IList<ComponentProperty> Components { get; set; }
        }
        public class ComponentProperty
        {
            public string PropertyName { get; set; }
            public string Value { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test");
                new Ntity
                {
                    Components = new List<ComponentProperty> {
                        new ComponentProperty {
                            PropertyName = "test",
                            Value = "the RED color" }
                    }
                }.Save();
                new Ntity
                {
                    Components = new List<ComponentProperty> {
                        new ComponentProperty {
                            PropertyName = "test",
                            Value = "the Green color" }
                    }
                }.Save();
                var result = DB.Queryable<Ntity>()
                               .Where(e => e.Components.Any(c => c.Value.ToLower().Contains("green")))
                               .ToList();
            }
        }
    }

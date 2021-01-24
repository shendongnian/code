    using System.Collections.Generic;
    namespace MyCmdlets
    {
        public class Suite
        {
            public string Name { get; set; }
            public List<Set> Sets { get; } = new List<Set>();
            public Suite(string name) {
                Name = name;
            }
        }
        public class Set
        {
            public string Type { get; set; }
            public string Description { get; set; }
            public List<Option> Options { get; } = new List<Option>();
            public Set(string type, string description) {
                Type = type;
                Description = description;
            }
        }
        public class Option 
        {
            public string Color { get; set; }
            public string Place { get; set; }
            public Option(string color, string place) {
                Color = color;
                Place = place;
            }
        }
    }

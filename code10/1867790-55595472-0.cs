    using System;
    using System.Linq;
    
    namespace Solution
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                var factory = new ClassAFactory(groupNumber: 1, isAvailable: true);
                var listAs = new[] { "PersonA", "PersonB", "PersonC" }
                                   .Select(name => factory.CreateClassA(name))
                                   .ToList();
            }
        }
    
        public class ClassA
        {
            public int GroupNumber { get; set; }
            public string Name { get; set; }
            public bool IsAvailable { get; set; }
        }
    
        public class ClassAFactory
        {
            private int GroupNumber { get; }
            public bool IsAvailable { get; }
    
            public ClassAFactory(int groupNumber, bool isAvailable)
            {
                GroupNumber = groupNumber;
                IsAvailable = isAvailable;
            }
    
            public ClassA CreateClassA(string name)
            {
                return new ClassA { GroupNumber = GroupNumber, Name = name, IsAvailable = IsAvailable };
            }
        }
    }

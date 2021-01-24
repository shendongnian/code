    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var source = new[]
                {
                    new Entry { Id = 1, DateTime = DateTime.Parse("21.05.2019 10:00:00") },
                    new Entry { Id = 2, DateTime = DateTime.Parse("21.05.2019 10:10:00") },
                    new Entry { Id = 3, DateTime = DateTime.Parse("21.05.2019 10:20:00") },
                    new Entry { Id = 4, DateTime = DateTime.Parse("21.05.2019 10:30:00") },
                    new Entry { Id = 5, DateTime = DateTime.Parse("21.05.2019 10:40:00") },
                    new Entry { Id = 6, DateTime = DateTime.Parse("21.05.2019 10:50:00") },
                    new Entry { Id = 7, DateTime = DateTime.Parse("21.05.2019 11:00:00") }
                };
    
                var destination = new[]
                {
                    new Entry { Id = 1, DateTime = DateTime.Parse("21.05.2019 09:00:00") },
                    new Entry { Id = 3, DateTime = DateTime.Parse("21.05.2019 10:25:00") },
                    new Entry { Id = 5, DateTime = DateTime.Parse("21.05.2019 10:45:00") },
                    new Entry { Id = 7, DateTime = DateTime.Parse("21.05.2019 10:30:00") },
                    new Entry { Id = 9, DateTime = DateTime.Parse("21.05.2019 10:40:00") },
                    new Entry { Id = 11, DateTime = DateTime.Parse("21.05.2019 10:50:00") }
                };
    
                var comparer = new EntryComparer();
                var partA = source.Except(destination, comparer);
                var partB = source.Intersect(destination, comparer)
                                  .Where(i => source.First(j => j.Id == i.Id).DateTime >
                                              destination.First(j => j.Id == i.Id).DateTime);
                var result = partA.Concat(partB);
                foreach (var i in result)
                    Console.WriteLine(i);
            }
    
            private class Entry
            {
                public int Id { get; set; }
                public DateTime DateTime { get; set; }
    
                public override string ToString() => $"{Id} {DateTime}";
            }
    
            private class EntryComparer : IEqualityComparer<Entry>
            {
                public bool Equals(Entry x, Entry y) => x.Id.Equals(y.Id);
    
                public int GetHashCode(Entry obj) => obj.Id.GetHashCode();
            }
        }
    }

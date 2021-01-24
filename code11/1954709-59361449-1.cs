    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Linq;
    namespace StackOverflow
    {
        public class Test : Entity
        {
            public string Name { get; set; }
            public SubTest[] SubCollection { get; set; }
        }
        public class SubTest
        {
            public Date DateTimeProp { get; set; }
            public Date OtherDateTimeProp { get; set; }
        }
        public class Date
        {
            private long ticks = 0;
            private DateTime date = new DateTime();
            public long Ticks
            {
                get => ticks;
                set { date = new DateTime(value); ticks = value; }
            }
            public DateTime DateTime
            {
                get => date;
                set { date = value; ticks = value.Ticks; }
            }
            public static implicit operator Date(DateTime dt)
            {
                return new Date { DateTime = dt };
            }
            public static implicit operator DateTime(Date dt)
            {
                if (dt == null) throw new NullReferenceException("The [Date] instance is Null!");
                return new DateTime(dt.Ticks);
            }
        }
        public class Program
        {
            private static void Main(string[] args)
            {
                new DB("test", "localhost");
                (new[] {
                    new Test{
                        Name = "one",
                        SubCollection = new[]{
                            new SubTest{ OtherDateTimeProp = DateTime.UtcNow, DateTimeProp = DateTime.UtcNow.AddMinutes(50)}, // should match
                            new SubTest{ OtherDateTimeProp = DateTime.UtcNow, DateTimeProp = DateTime.UtcNow.AddMinutes(60)}
                        }
                    },
                    new Test{
                        Name = "two",
                        SubCollection = new[]{
                            new SubTest{ OtherDateTimeProp = DateTime.UtcNow, DateTimeProp = DateTime.UtcNow.AddMinutes(60)},
                            new SubTest{ OtherDateTimeProp = DateTime.UtcNow, DateTimeProp = DateTime.UtcNow.AddMinutes(60)}
                        }
                    }
                }).Save();
                var result = DB.Queryable<Test>() // use collection.AsQueryable() for official driver
                               .SelectMany(t =>
                                    t.SubCollection,
                                   (t, s) => new
                                   {
                                       isMatch = s.DateTimeProp.Ticks < s.OtherDateTimeProp.Ticks + TimeSpan.FromMinutes(59).Ticks,
                                       t.ID,
                                       t.Name
                                   })
                               .Where(x => x.isMatch)
                               .Select(x => x.ID)
                               .ToList();
            }
        }
    }

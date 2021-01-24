    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Linq;
    namespace StackOverflow
    {
        public class Test : Entity
        {
            public Event[] History { get; set; }
        }
        public class Event
        {
            public bool flag { get; set; }
            public string status { get; set; }
        }
        public class Program
        {
            private static void Main(string[] args)
            {
                new DB("test", "localhost");
                (new[] {
                    new Test { History = new[]{
                        new Event { flag = true, status = "PROCESSED" } } },
                    new Test { History = new[]{
                        new Event { flag = true, status = "NOT-PROCESSED" },
                        new Event { flag = true, status = "NOT-PROCESSED" }
                    }}
                }).Save();
                var field = Prop.PosAll<Test>(t => t.History[0].flag);
                DB.Update<Test>()
                  .Match(t => t.History.Any(h => h.status != "PROCESSED"))
                  .Modify(b => b.Set(field, false))
                  .Execute();
            }
        }
    }

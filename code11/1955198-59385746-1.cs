    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    namespace StackOverflow
    {
        public class Test : Entity
        {
            public string Name { get; set; }
            public Quote[] Quotes { get; set; } = new Quote[0];
        }
        public class Quote
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
                    new Test { Name = "no quotes"},
                    new Test { Quotes = new[]{
                        new Quote { flag = true, status = "PROCESSED" } } },
                    new Test { Quotes = new[]{
                        new Quote { flag = true, status = "NOT-PROCESSED" },
                        new Quote { flag = true, status = "NOT-PROCESSED" }
                    }}
                }).Save();
                var field = Prop.PosAll<Test>(t => t.Quotes[0].flag);
                DB.Update<Test>()
                  .Match(_ => true) //.Match(t => t.History.Any(h => h.status != "PROCESSED"))
                  .Modify(b => b.Set(field, false))
                  .Execute();
            }
        }
    }

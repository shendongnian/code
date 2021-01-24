        class Program
        {
            static void Main(string[] args)
            {
                {
                    List<Foo> foo = new List<Foo>() {
                            new Foo() {
                                Id = 1,
                                Bars = new List<Bar>() {
                                    new Bar() { Name = "Johnson"},
                                    new Bar() { Name = "Johnson"},
                                    new Bar() { Name = "Johnson"},
                                    new Bar() { Name = "Cederic"},
                                    new Bar() { Name = "Cederic"}
                                }
                            }
                    };
                    var foos = foo.SelectMany(x => x.Bars.Select(y => new { Id = x.Id, Name = y.Name }).ToList());
                    List<Foo> results = foos.GroupBy(x => new { Id = x.Id, Name = x.Name })
                        .Select(x => new Foo() { Id = x.Key.Id, Bars = x.Select(y => new Bar() { Name = y.Name }).ToList() })
                        .ToList();
                }
            }
        }
        public class Foo
        {
            public int Id { get; set; }
            public List<Bar> Bars { get; set; }
        }
        public class Bar
        {
            public string Name { get;set;}
        }

    // an example status enum
    enum SomeStatus
    {
        Open,
        Closed,
        Funky,
    }
    // Blarg<TStatus> is just some container class.  This isn't necessary, but it allows TStatus to be a generic parameter rather than a specific type.
    class Blarg<TStatus>
    {
        public class Bar
        {
            public string Code;
            public string Message;
            public TStatus Status;
        }
        public class Foo
        {
            public List<Bar> Bar = new List<Bar>();
            public string Something;
            public TStatus Status;
            public IEnumerable<Bar> BarsFilteredByStatus
            {
                get
                {
                    // return a filtered collection of bars where Bar.Status equals Foo.Status
                    foreach (var bar in this.Bar)
                    {
                        if (this.Status.Equals(bar.Status))
                            yield return bar;
                    }
                }
            }
        }
    }
    // Code from this point on is a usage example
    class Program
    {
        static void Main(string[] args)
        {
            // set up some example data
            var bars = new List<Blarg<SomeStatus>.Bar>();
            bars.Add(new Blarg<SomeStatus>.Bar { Code = "123", Status = SomeStatus.Open });
            bars.Add(new Blarg<SomeStatus>.Bar { Code = "234", Status = SomeStatus.Closed });
            bars.Add(new Blarg<SomeStatus>.Bar { Code = "345", Status = SomeStatus.Funky });
            bars.Add(new Blarg<SomeStatus>.Bar { Code = "456", Status = SomeStatus.Open });
            bars.Add(new Blarg<SomeStatus>.Bar { Code = "567", Status = SomeStatus.Funky });
            // create a Foo object
            Blarg<SomeStatus>.Foo foo = new Blarg<SomeStatus>.Foo
            {
                Bar = bars,
                Status = SomeStatus.Open,
            };
            // now iterate over the Foo.BarsFilteredByStatus property
            // This will iterate over all Bar objects contained within Foo.Bar where Bar.Status equals Foo.Status
            foreach (var bar in foo.BarsFilteredByStatus)
            {
                Console.WriteLine(bar.Code);
            }
        }
    }

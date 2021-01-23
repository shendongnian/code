    public class Foo
    {
        public string First { get; set; }
        public string Second { get; set; }
        public override string ToString()
        {
            return First + ',' + Second;
        }
    }

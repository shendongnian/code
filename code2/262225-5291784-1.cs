    public class Foobar
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public Foobar Foobar1(string param1 = "foo", string param2 = "bar")
        {
            Foobar f = new Foobar();
            f.Foo = param1;
            f.Bar = param2;
            return f;
        }
    }

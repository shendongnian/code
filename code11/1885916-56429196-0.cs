    public class FooA
    {
        public double A { get; set; }
        public double B { get; set; }
    }
    public class FooAFake
    {
        public double A { get; set; }
        public double B { get; set; }
    }
    public class FooB : FooA
    {
        public double C { get; set; }
    }
    public class FooBFake : FooAFake
    {
        public double C { get; set; }
    }
    public class FooC : FooBFake
    {        
    }
    public class FooD : FooC
    {
        public double D { get; set; }
    }
    public class FooA1 : FooAFake
    {        
    }

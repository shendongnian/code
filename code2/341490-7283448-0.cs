    class Test {
        public int SomeValue { get; set; }
        public Test(int someValue) { this.SomeValue = someValue; }
    }
    
    Test x = new Test(42);
    Test y = x;
    x = new Test(23);
    Console.WriteLine(x.SomeValue + " " + y.SomeValue);

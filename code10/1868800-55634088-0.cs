     static void Main(string[] args)
        { 
            var test = new test { abc = "asdasdasd" };
            var xx = (dynamic)test;
            Console.WriteLine(xx.abc);
        }
        class test
        {
            public string abc { get; set; }
        }

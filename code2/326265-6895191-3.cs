        [Test]
        public void Test()
        {
            dynamic d;
            int i = 20;
            d = (dynamic) i;
            Console.WriteLine(d);
        }
        [Test]
        public void Test2()
        {
            dynamic d;
            int i = 20;
            d = (dynamic)new { a = 1, b = 12.2, c = "some text" };
            MethodA(d);
            Console.WriteLine(d);
        }
        public void MethodA(dynamic o)
        {
        }

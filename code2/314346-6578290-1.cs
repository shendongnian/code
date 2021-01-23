    Wrapper<int> wrapper = new Wrapper<int>(1);
    ...
    TestClass tc = new TestClass(wrapper);
    Console.WriteLine(wrapper.Value); // 1
    tc.ModifyWrapper();
    Console.WriteLine(wrapper.Value); // 2
    ...
    class TestClass
    {
        private readonly Wrapper<int> wrapper;
        public TestClass(Wrapper<int> wrapper)
        {
            this.wrapper = wrapper;
        }
        public void ModifyWrapper()
        {
            wrapper.Value = 2;
        }
    }

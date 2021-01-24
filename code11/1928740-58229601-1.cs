    public class DoSmthWhichCurrentlyNeedsTest1
    {
        private IEnumerable<ITest> test;
        public DoSmthWhichCurrentlyNeedsTest1(IEnumerable<ITest> test)
        {
            this.test = test;
        }  
        public string Get()
        {
            var flag = test.FirstOrDefault(h => h.GetType().Name == "Test1");
            var value = flag?.play();
            return value;
        }
    }
    public class DoSmthWhichCurrentlyNeedsTest2
    {
        private IEnumerable<ITest> test;
        public DoSmthWhichCurrentlyNeedsTest2(IEnumerable<ITest> test)
        {
            this.test = test;
        }
        public string Get() 
        {
            var flag = test.FirstOrDefault(h => h.GetType().Name == "Test2");
            var value = flag?.play();
            return value;
        }
    }

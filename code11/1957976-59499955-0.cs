    public class Test
    {
        private int _c;
        ...
        public int Add(int a, int b)
        {
            return a + b + _c;
        }
    }
    ...
    var testInstance = new Test();
    var addDelegate = new TestDelegate(testInstance.Add);

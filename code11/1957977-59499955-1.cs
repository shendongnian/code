    public class Test
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
    var addDelegate = new TestDelegate(Test.Add);

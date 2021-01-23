    public delegate void MyStaticMethodInvoker(params object[] values);
    public class TestStatic
    {
        public static void TestMethod1(params object[] values)
        {
            Console.WriteLine("TestMethod1 invoked");
        }
        public static void TestMethod2(params object[] values)
        {
            Console.WriteLine("TestMethod2 invoked");
        }
        public static void TestMethod3(params object[] values)
        {
            Console.WriteLine("TestMethod3 invoked");
        }
    }
    public class TestClass
    {
        private MyStaticMethodInvoker _targetMethod;
        public TestClass(MyStaticMethodInvoker targetMethod)
        {
            _targetMethod = targetMethod;
        }
        public void CallTargetedStaticMethod()
        {
            _targetMethod.Invoke(1,2,3,4);
        }
    }

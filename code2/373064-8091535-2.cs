    class TestDestructor
    {
        public TestDestructor()
        {
            testList = new List<string>();
        }
        public static volatile bool DestructorCalled;
        ~TestDestructor()
        {
            DestructorCalled = true;
        }
        public string xy = "test";
        public List<string> testList;
    }
    class Test
    {
        private static object[] myArray;
        static void Main()
        {
            NewMethod();            
            myArray = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(TestDestructor.DestructorCalled);
            Console.In.ReadToEnd();
        }
        private static void NewMethod()
        {
            TestDestructor testDestructor = new TestDestructor() { xy = "foo" };
            testDestructor.testList.Add("bar");
            myArray = new object[] { testDestructor };
            Console.WriteLine(myArray.Length);
        }
    }

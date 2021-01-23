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
        static void Main()
        {
            NewMethod();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(TestDestructor.DestructorCalled);
            Console.In.ReadToEnd();
        }
        private static void NewMethod()
        {
            TestDestructor testDestructor = new TestDestructor() { xy = "foo" };
            testDestructor.testList.Add("bar");
            var array = new object[] { testDestructor };
            Console.WriteLine(array.Length);
            array = null;
            testDestructor = null;
        }
    }

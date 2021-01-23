        public static volatile bool DestructorCalled;
        ~TestDestructor()
        {
            DestructorCalled = true;
        }
        public string xy = "test";
    }
    class Test
    {
        static void Main()
        {
            TestDestructor testDestructor = new TestDestructor() { xy = "foo" };
            var array = new object[] { testDestructor };
            Console.WriteLine(array.Length);
            array = null;
            testDestructor = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(TestDestructor.DestructorCalled);
            Console.In.ReadToEnd();
        }
    }

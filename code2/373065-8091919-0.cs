    class TestDestructor
    {
        public static bool DestructorCalled;
        ~TestDestructor()
        {
            DestructorCalled = true;
        }
    }
    
    class Test
    {
        static void Main()
        {
            TestDestructor testDestructor = new TestDestructor();
    
            var array = new object[] { testDestructor };
            Console.WriteLine(array[0].ToString());
            array = null;
    
            testDestructor = null;
    
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(TestDestructor.DestructorCalled);
        }
    } 

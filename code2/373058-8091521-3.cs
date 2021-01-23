    using System;
    
    class TestDestructor
    {
        public static volatile bool DestructorCalled;
    
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
            array = null;
            
            testDestructor = null;
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(TestDestructor.DestructorCalled);
        }
    }

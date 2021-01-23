    namespace Test
    {
        enum Days
        {
            Monday, Tuesday
        }
        public class TestingClass
        {
            public delegate void DelTest(Days d);    // This will produce an error...
        }
    }

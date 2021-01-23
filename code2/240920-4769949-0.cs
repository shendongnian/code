    using System;
    
    class Test
    {
        public event EventHandler SomeEvent;
        
        public Test(Test other)
        {
            this.SomeEvent = other.SomeEvent;
        }
    }

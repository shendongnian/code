    public class TestOne
    {
    	public TestOne()
    	{
    	}
    
        public TestInner TestProperty
        {
            get;
            set;
        }
        
        public class TestInner
        {
            
            public String TestInnerProperty
            {
                get;
                set;
            }
        }
    }

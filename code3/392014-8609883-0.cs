    public class MyException : Exception
    {
        public System.Reflection.MethodBase TargetSite
        {
            get { return null; }
        }
	
        public FooException() : base()
        {
	
        }
    }

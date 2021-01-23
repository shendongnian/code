    public class MyException : Exception
    {
        public new System.Reflection.MethodBase TargetSite
        {
            get { return null; }
        }
	
        public MyException() : base()
        {
	
        }
    }

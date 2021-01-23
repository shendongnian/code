    public class MyBusinessService
    {
        private static MyBusinessService mInstance = null;
    
        public static MyBusinessService Instance
        {
            get { return mInstance; }
        }
    
        static MyBusinessService()
        {
            mInstance = new MyBusinessService();
        }
    
        private MyBusinessService() {}
    }

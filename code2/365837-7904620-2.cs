    public class MyBusinessService
    {
        //the instantiation will not happen until the Instance property is called
        private static readonly MyBusinessService mInstance = new MyBusinessService();
    
        public static MyBusinessService Instance
        {
            get { return mInstance; }
        }
    
        private MyBusinessService() {}
    }

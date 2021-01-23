    public class MyClass
    {
        private readonly IMyService myservice;
        public MyClass(IMyService myservice)
        {
            if (myservice == null)
            {
                throw new ArgumentNullException("myservice");
            }
            this.myservice = myservice;
        }
    }

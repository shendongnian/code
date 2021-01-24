    public class A
    {
        public B refToB;
    
        void Start()
        {
            //we call the function here
            refToB.Test();
        }
    }
    
    public class B
    {
        public void Test(){
            //we can do something here :)
        }
    }

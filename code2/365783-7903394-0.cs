    public class A
    {
        public int x;
        protected int y;
        private int z;
    }
    public class B : A
    {
        public int CallPro()
        {
            return y;
        }
        public int CallPriv()
        {
            return z; //error 
        }
    }
    static void Main()
    {
        A oa;
        oa.x; //Fine
        oa.y; //Error
        oa.z; //Error
        
    }

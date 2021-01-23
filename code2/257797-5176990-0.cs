    public class Example1
    {
        public static int Test() { return 0; }
    
        public Example1()
        {
            this.Test();  // This doesn't work
            Example1.Test();  // This does
        }
    }

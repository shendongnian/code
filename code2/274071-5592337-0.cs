    public class Another1
    {
        public Another2 Call1()
        {
            // some code
            return new Another2();  
            // could pass 'this' to Another2 constructor so it has all state
        }
    }
    
    public class Another2
    {
        public void Call2()
        {
            // some more code
        }
    }

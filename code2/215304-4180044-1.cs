    public class Test
    {    
        private int result, other;
        public Test() : this(PrepareArgument())
        {        
           // Do some other stuff.        
           other = 2;    
        }    
        public Test(int number)    
        {        
            // Assign inner variables.        
            result = number;    
        }
        private int PrepareArgument()
        {
             int argument;
             // whatever you want to do to prepare the argument
             return argument;
        }
   }
 

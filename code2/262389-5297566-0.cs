    public class test
    {
        private int i = 0;
    
        public test(){}
    
        public SetInt(object obj)
        {
            try
            {
                i = (int) obj;
                return i;
            }
            catch(exception ex)
            {
               throw; // This is enough. throwing ex resets the stack trace. This maintains it
            }
        }
    }

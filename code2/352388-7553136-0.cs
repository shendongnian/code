    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Top();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    
        static void Top()
        {
            try
            {
                Middle();
            }
            catch (Exception e)
            {
                throw new Exception("Exception from top", e);
            }
        }
    
        static void Middle()
        {
            try
            {
                Bottom();
            }
            catch (Exception e)
            {
                throw new Exception("Exception from middle", e);
            }
        }
        
        static void Bottom()
        {
            throw new Exception("Exception from bottom");
        }
    }

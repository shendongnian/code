    using System;
    using System.Reflection;
    
    class Program
    {
        static void Main(string[] args)  
        {
            var method = typeof(Program).GetMethod("ThrowException");
            try
            {
                method.Invoke(null, null);
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine("Caught exception: {0}", e.InnerException);
            }
        }
        
        public static void ThrowException()
        {
            throw new Exception("Bang!");
        }
    }

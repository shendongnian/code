    public class LoggingInterceptor : IInterceptor  
    {
        public void Intercept(IInvocation invocation)
        {
            // log method call and parameters
            try                                           
            {                                             
                invocation.Proceed();   
            }                                             
            catch (Exception e)              
            {                                             
                // log exception
                throw; // or sth else                
            }
        }                                             
    }

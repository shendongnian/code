    public interface IXYZServiceInvoker
    {
       SomeData SomeServiceCall();
    }    
    
    public class SomeServiceInvoker : IXYZServiceInvoker
    {
       public void SomeServiceCall()
       {
                 //Calls a real service    
       }        
    }    
    
    public class FakeServiceInvoker : IXYZServiceInvoker
    {
        public SomeData SomeServiceCall()
        {
                 //returns some dummy/test data    
        } 
    }

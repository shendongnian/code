    public class Base
    {
      public BlahaMethod()
      {
        try
        {
          DoBlaha();
        }
        catch(Exception ex)
        {
          OnException(ex);
        }
      }
    
      protected abstract void DoBlaha();
    
      private void OnException(Exception ex)
      {
        // Handle exception
      }
    }
    
    public class Derived
    {
      protected virtual void DoBlaha()
      {
        throw new NotImplementedException();
      }
    }

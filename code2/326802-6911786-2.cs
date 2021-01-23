    public class MyObjectListener
    {
         private readonly MyObject _object;
         public class MyObjectListener(MyObject obj)
         {
              _object = obj;
              Attach();
         }
         // adds event handlers
         private void Attach()
         {
             obj.UpdateSucceeded += UpdateSuceededHandler;
             obj.UpdateFailed += UpdateFailedHandler;
         }
 
         // removes event handlers
         private void Detach()
         {
             obj.UpdateSucceeded -= UpdateSuceededHandler;
             obj.UpdateFailed -= UpdateFailedHandler;
         }
         ...
    }

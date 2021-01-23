public class ClassExample
{
   private object asyncCallToken = new object();
   public ClassExample(int someParameter)
   {
      GetAsyncMethodCompleted += ClassExampleGetAsyncMethodCompleted;
      GetAsyncMethod(someParameter, asyncCallToken);
   }
   void ClassExampleGetAsyncMethodCompleted (object sender, Args e)
   {
      if (e.UserState != asyncCallToken)
      {
          // the event was triggered by somebody's other call.
          return;
      }
      GetAsyncMethodCompleted -= ClassExampleGetAsyncMethodCompleted;
   }
}

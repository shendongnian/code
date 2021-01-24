public void CallLocked(Action method)
{
  if (method != null)
    lock (LockObject)
      method();
}
Usage:
    CallLocked(Wrapper.DeleteAllSequences);
Or:
CallLocked(() => { Wrapper.SomeMethod(somearg); });
CallLocked(()=>
{
    Wrapper.DeleteAllSequences();
    Wrapper.UploadSequence();
    Wrapper.StartSequence();
});
You need to create as many `CallLocked` overloads as different methods signatures you need to call.
Since there is no language keyword to do that for example, it is the best you can do even if it *seems* to be poor solution:
    threadlock Wrapper.DeleteAllSequences();
I wrote *it seems* because in the `CallLocked` you can add any `try catch` and other flow control management you want...
enum ExceptionBehavior { Hide, Show, Raise };
public void CallLocked(Action method, 
                       ExceptionBehavior exceptionBehavior = ExceptionBehavior.Raise)
{
  if (method != null)
    lock (LockObject)
      try
      {
        method();
      }
      catch ( Exception ex )
      {
        switch ( exceptionBehavior )
        {
          case ExceptionBehavior.Hide;
            break;
          case ExceptionBehavior.Show;
            MessageBox.Show(...);
            break;
          case ExceptionBehavior.Raise;
            throw;
        }
      }
}

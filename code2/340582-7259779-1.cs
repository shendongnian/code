     public class SynchronousInvoker : MethodInvoker
     {
         public override void Invoke(Action begin, Action<IAsyncResult> end)
         {
             begin();
             end();
         }
     }

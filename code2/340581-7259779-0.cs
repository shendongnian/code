     public class MethodInvoker
     {
         public virtual void Invoke(Action begin, Action<IAsyncResult> end)
         {
              begin.BeginInvoke(end, null);
         }
     }

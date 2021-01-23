    public class MethodInvoker
    {
        public virtual void InvokeMethod(Action method, Action callback)
        {
             method.BeginInvoke(callback, method);
        }
    }

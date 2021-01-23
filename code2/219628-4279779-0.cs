    public interface IActionBase
    {
           bool HasResult { get; }
           void Execute() { }
           object Result { get; }
    }
    public interface IActionBase<T> : IActionBase
    {
           new T Result { get; }
    }
    public sealed class ActionWithReturnValue<T> : IActionBase<T>
    {
           public ActionWithReturnValue(Func<T> action) {  _action = action; }
           private Func<T> _action;
           public bool HasResult { get; private set; }
           object IActionBase.Result { get { return this.Result; } }
           public T Result { get; private set; }
           public void Execute()
           {
                HasResult = false;
                Result = default(T);
                try 
                { 
                     Result = _action();
                     HasResult = true;
                 }
                catch
                {
                    HasResult = false;
                    Result = default(T);   
                }  
           }
    }
    public sealed class ActionWithoutReturnValue : IActionBase
    {
          public bool HasResult { get { return false; } }
          object IActionBase.Result { get { return null; } }
          public void Execute() { //... }
    }

    public interface IEnumerator<out T> : IDisposable, IEnumerator
    {
  
        void Dispose(); //inherited from IDsiposable
        Object Current {get;} //inherited from IEnumerator
        T Current {get;}
        bool MoveNext(); //inherited from IEnumerator
        void Reset(); //inherited from IEnumerator
    }
    [ComVisibleAttribute(true)]
    public interface IDisposable
    {
        void Dispose();
    }

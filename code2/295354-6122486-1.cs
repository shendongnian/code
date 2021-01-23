    public abstract class MyBaseClass : IMyInterface<MyBaseClass>
    {
        public virtual IEnumerable<T> Search<T>() where T : MyBaseClass, new()
        {
        }
    }

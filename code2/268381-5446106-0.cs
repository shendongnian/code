    public interface IOwned<out T> : IDisposable
    {
        T Value { get; }
    }
    public class OwnedWrapper<T> : Disposable, IOwned<T>
    {
        private readonly Owned<T> _ownedValue;
        public OwnedWrapper(Owned<T> ownedValue)
        {
            _ownedValue = ownedValue;
        }
        public T Value { get { return _ownedValue.Value; } }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _ownedValue.Dispose();
        }
    }

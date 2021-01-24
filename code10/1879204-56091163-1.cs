    internal class UnitOfWorkManager : IDisposable
    {
        public UnitOfWorkManager Current { get; private set; }
        public UnitOfWorkManager()
        {
            Current = this;
        }
        public UnitOfWorkManager DisableFilter(DataFilter dataFilter)
        {
            var manager = new UnitOfWorkManager();
            Console.WriteLine($"Created  UnitOfWorkManager {manger.GetHashCode()} with {dataFilter} disabled");
            return manager;
        }
        public void Dispose() { Console.WriteLine($"Disposed UnitOfWorkManager {GetHashCode()}"); }
    }

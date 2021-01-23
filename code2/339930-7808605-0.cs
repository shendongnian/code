    internal class ServiceStub: Service<DummyEntity>
    {
        private int _count;
        public int Count
        {
            get { return _count; }
        }
        public override void SaveBatch(IEnumerable<object> entities)
        {
           lock(this)
           {
               _count++;
           }
        }
        public ServiceStub(IRepository<DummyEntity> repository):base(repository)
        {
            _count = 0;
        }
    }

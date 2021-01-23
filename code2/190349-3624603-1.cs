    private interface IRepository
    {
        List<object> Load();
        void Save(List<object> data);
    }
    private class FooBar
    {
        private IRepository repository;
        public List<object> Objects { get; private set; }
        
        public FooBar(IRepository repository)
        {
            this.repository = repository;
        }
        
        public void Load()
        {
            Objects = repository.Load();
        }
        public void Save()
        {
            repository.Save(Objects);
        }
    }

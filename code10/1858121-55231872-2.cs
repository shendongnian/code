    class TestAutoDb : IAutoDb
    {
        public List<Auto> Autos = new List<Auto>();
        public Task<Auto> Create(Auto auto) {
            Autos.Add(auto);
            return Task.FromResult(auto);
        }
        public Task<Auto> Get(Guid id) => Task.Run(() => Autos.Find(x => x.Id == id));
        public Task<List<Auto>> GetAll() => Task.FromResult(Autos);
        public Task Remove(Auto model) => Task.Run(() => Autos.Remove(model));
        public Task Remove(Guid id) => Task.Run(() => Autos.RemoveAll(x => x.Id == id));
        public Task Update(Guid id, Auto model) => Remove(id).ContinueWith(_ => Create(model));
    }

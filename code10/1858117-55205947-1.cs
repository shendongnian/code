    public interface IAutoService {
        //..others omitted for brevity
        Task RemoveById(Guid id);
        Task<List<Auto>> GetAutos();
    }
    public class AutoService : IAutoService {
        private readonly IAutoDb _AutoDb;
        public AutoService(IAutoDb AutoDb) {
            _AutoDb = AutoDb;
        }
        //..others omitted for brevity
        public Task RemoveById(Guid id) {
            return _AutoDb.Remove(id);
        }
        public Task<List<Auto>> GetAutos() {
            return _AutoDb.GetAll();
        }
    }

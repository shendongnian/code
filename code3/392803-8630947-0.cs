    public abstract class ServiceBase<TModel> where TModel : new() {
        protected ServiceBase() { Model = new TModel(); }
        public TModel Model { get; private set; }
    }
    public class AService : ServiceBase<A> {
        ...
    }

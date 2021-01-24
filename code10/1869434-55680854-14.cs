    public interface ICommonProvider {
        ICommonRepository<T> GetRepository<T>();
    }
    public class CommonProvider : ICommonProvider {
        private readonly ILifetimeScope lifetimeScope;
        public CommonProvider(ILifetimeScope lifetimeScope) {
            this.lifetimeScope = lifetimeScope;
        }
        public ICommonRepository<T> GetRepository<T>() {
            return lifetimeScope.Resolve<ICommonRepository<T>>();
        }
    }

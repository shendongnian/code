    public interface ICommonProvider {
        ICommonRepository<T> GetRepository<T>();
    }
    public class CommonProvider : ICommonProvider {
        private readonly IContainer container;
        public CommonProvider(IContainer container) {
            this.container = container;
        }
        public ICommonRepository<T> GetRepository<T>() {
            return container.Resolve<ICommonRepository<T>>();
        }
    }

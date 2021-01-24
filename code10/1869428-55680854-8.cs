    public interface ICommonProvider {
        ICommonRepository<T> GetRepository<T>();
    }
    public class CommonProvider : ICommonProvider {
        private readonly Container container;
        public CommonProvider(Container container) {
            this.container = container;
        }
        public ICommonRepository<T> GetRepository<T>() {
            return container.Resolve<ICommonRepository<T>>();
        }
    }

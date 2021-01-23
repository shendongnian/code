    public class RepoRouter<T> : IRepo<T> where T : Entity
    {
        private static readonly bool isDelType;
        private readonly IWindsorContainer container;
        static RepoRouter()
        {
            isDelType = typeof(IDel).IsAssignableFrom(typeof(T));
        }
        public RepoRouter(IWindsorContainer container)
        {
            this.container = container;
        }
        // Implement all interface members of IRepo<T> here.
        void IRepo<T>.MyInterfaceMethod(T value)
        {
            this.GetRepo().MyInterfaceMethod(value);
        }
        private IRepo<T> GetRepo()
        {
            return isDelType ?
                this.container.Resolve<DelRepo<T>>() :
                this.container.Resolve<EntRepo<T>>();
        }
    }

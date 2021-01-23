    public interface ITransientDependency
    {
        void SomeAction();
    }
    public class Implementation : ITransientDependency
    {
        public SomeAction() { ... }
    }

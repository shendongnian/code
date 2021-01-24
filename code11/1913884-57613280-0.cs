    public interface ILauncherCommand<in T> where T : IBaseParam
    {
        void launch(T parameters);
    }
    public class BaseCommand<T> : ILauncherCommand<T> where T : IBaseParam  
    {
        string Name { get; }
        public void launch(T parameters)
        {
        }
    }
    public class ComplexCommand<T> : ILauncherCommand<T> where T : IComplexParam
    {
        string Name { get; }
        public void launch(T parameters)
        {
        }
    }

    public class AutoMock : IDisposable
    {
        //...  
        public IContainer Container { get; }
        public static AutoMock GetLoose(Action<ContainerBuilder> beforeBuild);
        //...
    }

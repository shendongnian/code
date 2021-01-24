    public class DemoHub : Hub<ITypedClient>
    {
    }
    public interface ITypedClient
    {
        void Test();
    }

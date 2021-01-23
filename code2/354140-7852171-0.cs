    [ServiceContract]
    public interface IMyServiceContract
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ping")]
        string Ping();
    }
    public class ProxyClient : ClientBase<IMyServiceContract>, IMyServiceContract
    {
        #region Implementation of IMyServiceContract
        public string Ping()
        {
            return Channel.Ping();
        }
        #endregion
    }
    public class Test
    {
        // This assumes you have setup a client endpoint in your .config file
        // that is bound to IMyServiceContract.
        var client = new Client();
        System.Console("Ping replied: " + client.Ping());
    }

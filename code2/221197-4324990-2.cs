    using System.Net;
    public interface IMyDataInterface
    {
        NetworkCredential credentials { get; set; }
    }
    public class MyDataLayer : IMyDataInterface
    {
        public MyDataLayer(NetworkCredential loginInfo)
        {
            credentials = loginInfo;
        }
    }

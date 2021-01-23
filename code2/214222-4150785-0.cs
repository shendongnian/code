    public interface IHttpHelper
    { }
    public class RealHttpHelper
    { ... }
    public class FakeHttpHelper 
    { ... }
    public static class HttpHelper 
    {
        public static IHttpHelper Instance
        {
            get 
            {
                return whatever ? new RealHttpHelper() : new FakeHttpHelper();
            }
        }
    }
    ...
    HttpHelper.Instance.Context...
    ...

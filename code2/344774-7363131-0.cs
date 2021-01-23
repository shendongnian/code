    public interface IRequest
    {
        IResponse GetResponse(string url);
        IResponse GetResponse(string url, object data);
    }
    public interface IResponse
    {
        Stream GetStream();
    }

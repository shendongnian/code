    public interface IReplyTypeMapper
    {
        Type GetReplyType(string replyName);
    }
    public interface IHandlerFactory
    {
        IReplyHandler GetHandler(Type contentType);
    }

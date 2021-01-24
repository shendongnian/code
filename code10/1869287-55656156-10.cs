    public interface IReplyHandler
    {
        void HandleReply(object content);
    }
    public abstract class BaseHandler<T> : IReplyHandler
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));
 
        public void HandleReply(object content)
        {
            HandleReplyContent((T)content);
        }
        protected abstract void HandleReplyContent(T content);
    }

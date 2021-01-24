    public interface INewSend 
    {
        void Send(IEntity entity, string userName); // pass entity instead of its ID
        IEnumerable <IEntity> GetNotSent(); 
    }

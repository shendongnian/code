    public interface IEntity 
    {
        void DoTask();
    }
    public interface IExtendedTaskEntity : IEntity
    {
        void DoExtendedTask();
    }
    public class ConcreteEntity : IExtendedTaskEntity 
    {
        #region IExtendedTaskEntity Members
        public void DoExtendedTask()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IEntity Members
        public void DoTask()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

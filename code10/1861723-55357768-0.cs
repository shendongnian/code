        public interface IEntity
        {
            
        }
    
        public interface IFileEntity : IEntity
        {
            ...
        }
        public interface IWatchService<out TDataEntity> where TDataEntity : IEntity //note the "out" keyword here.
        {
        }

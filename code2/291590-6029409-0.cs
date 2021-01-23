    public interface IProcessor
    {         
        ICollection<OutputEntity> Process(InputEntity> entity);
        bool CanProcess (InputEntity entity);
    }

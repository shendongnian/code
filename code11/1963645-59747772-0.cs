    public abstract class StrategyBase
    {
       public abstract bool CanProcess(string fileType);
       public virtual void Execute(File file)
       {
            _service.SaveInDatabase(file);
       }
    }

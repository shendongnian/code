    public interface IMyInterface<T>
    {
        IQueryable<T> All { get; }
    }
    public abstract class MyBaseClass<T> : IMyInterface<T>
    {
        public virtual IQueryable<T> All
        {
            get { return _unitOfWork.GetList<T>(); ; }
        }
    }
    public class MyClass : MyBaseClass<Suggestion>, IMyInterface<Suggestion>
    {
        
    }
    

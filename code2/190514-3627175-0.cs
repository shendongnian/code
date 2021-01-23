    public interface IMyInterface<T>
    {
        IQueryable<T> All { get; }
    }
    public abstract class MyBaseClass<T> : IMyInterface<T>
    {
        virtual public IQueryable<T> All
        {
            get { return _unitOfWork.GetList<T>(); ; }
        }
    }
    public class MyClass : MyBaseClass<Suggestion>, IMyInterface<Suggestion>
    {
        
    }
    

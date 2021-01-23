    public interface IVisitable<T>
    {
        void Accept(IVisitor<T> visitor);
    }
    
    public interface IVisitor<T>
    {
        bool Visit(T item);
    }

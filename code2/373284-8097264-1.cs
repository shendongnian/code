    public interface IFirst
    { ... }
    
    public interface ISecond : IFirst
    { ... }
    
    public void DoWork(IFirst obj) {...}
    
    public void DoWork(ISecond obj)
    {
        DoWork(obj as IFirst);
        
        /* ISecond calls */
    }

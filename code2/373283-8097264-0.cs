    public interface IFirst
    { ... }
    
    public interface ISecond : IFirst
    { ... }
    
    public void DoFirst(IFirst obj) {...}
    
    public void DoSecond(ISecond obj)
    {
        DoFirst(obj as IFirst);
        
        /* ISecond calls */
    }

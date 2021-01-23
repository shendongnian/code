    public interface IFirstName
    {
        string FName { get; }
    }
    
    public void methodName(IFirstName objectWithFirstName)
    {
        string name = objectWithFirstName.FName;
    }

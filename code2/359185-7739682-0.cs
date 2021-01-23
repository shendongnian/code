    public interface IBasicInfo
    {
        string Name { get; }
        string Id { get; }
    }
    
    internal interface IFullInfo : IBasicInfo
    {
        string Address { get; }
    }
    
    internal interface IInternalStuff
    {
        Stuff Data { get; }
    }
    

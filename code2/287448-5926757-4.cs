    public interface IWellKnown<TData> where TData : struct
    {
        TData PropertyA { get; }
        TData PropertyB { get; }
    }

    public interface IMyContractAsync
    {
        Task<int> Add(int a, int b);
    }
    
    public interface IMyContract : IMyContract2Async
    {
        int Add(int a, int b);
    }

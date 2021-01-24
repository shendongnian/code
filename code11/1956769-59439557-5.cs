    public interface IMyContractAsync
    {
        Task<int> Add(int a, int b);
    }
    
    public interface IMyContract : IMyContractAsync
    {
        int Add(int a, int b);
    }

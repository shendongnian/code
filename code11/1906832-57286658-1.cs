    public interface IDemoClient
    {
        Task ReceiveMessage(string message);
        Task ReceiveData(MyData data, string message);
    }

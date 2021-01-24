    public interface ITrackingDisposable : IDisposable
    {
        //The implementation of the actual disposings
        Task FinishDisposeAsync();
    }

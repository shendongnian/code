    class Gateway : IDisposable {
      private int runningTaskCount;
      public AsyncConditionVariable Completion { get; } = new AsyncConditionVariable( new AsyncLock() );
      public Gateway() {
      }
      public void Dispose() {
        if (runningTaskCount != 0) throw new InvalidOperationException( "You can not call this method when tasks are running" );
      }
    
      public async Task<Data> Request1 () {
        BeginTask();
        ...
        EndTask();
      }
      private void BeginTask() {
        Interlocked.Increment( ref runningTaskCount );
      }
      private void EndTask() {
        var result = Interlocked.Decrement( ref runningTaskCount );
        if (result == 0) Completion.NotifyAll();
      }
    }

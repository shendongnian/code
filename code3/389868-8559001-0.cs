    public class CommandManager
    {
        private readonly SynchronizationContex _synchronizationContex;
        public CommandManager(SynchronizationContext synchronizationContex)
        {
            _synchronizationContex = synchronizationContex;
        }
        public void ExecuteAsync(Func<State> action, Action<State> callback)
        {
            ThreadPool.QueueUserWorkItem(o => {
                                                 state = action();
                                                 _synchronizationContex.Send(oo => callback(state));
                                              }
        } 
    }

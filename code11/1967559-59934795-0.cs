    public enum SafeProcessState { Exit = 1, Killed = 2 }
    public class SafeProcess
    {
        private readonly Process process;
        private readonly Func<bool> killPredicate;
        public SafeProcess(Func<bool> killPredicate, Process process)
        {
            this.killPredicate = killPredicate;
            this.process = process;
        }
        public async Task<SafeProcessState> WaitAsync()
        {
            var state = SafeProcessState.Exit;
            while (true) 
            {
                await Task.Delay(100);
                if (this.killPredicate())
                {
                    state = SafeProcessState.Killed;
                    this.process.Kill();
                    break;
                }
                else if (this.process.HasExited) 
                {
                    break;
                }
            }
            return state;
        }
    }

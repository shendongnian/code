    public interface IProcessorThread
        {
            void Start();
    
            void Stop();
        }
    
        public abstract class BaseProcessorThread : IProcessorThread
        {
            protected Boolean IsRunning;
            protected readonly Thread ServiceThread;
            protected readonly Int32 PollingFrequencySeconds;
    
            #region Constructors
    
            protected BaseProcessorThread(Int32 pollingFrequencySeconds)
            {
                this.PollingFrequencySeconds = pollingFrequencySeconds;
                ServiceThread = new Thread(Process);
            }
    
            #endregion
    
            #region Protected Methods
    
            protected abstract void Process();
    
            #endregion
    
            #region Public Methods
    
            public void Start()
            {
                IsRunning = true;
                ServiceThread.Start();
            }
    
            public void Stop()
            {
                IsRunning = false;
                ServiceThread.Join(2000);
            }
    
            #endregion
        }
    
        public class LifetimeInfiniteThread : BaseProcessorThread
        {
            #region Fields
    
            private readonly Action actionMethod;
            private readonly Action<Exception> exceptionMethod;
    
            #endregion
    
            #region Constructors
    
            public LifetimeInfiniteThread(Int32 pollingFrequencySeconds, Action actionMethod, Action<Exception> exceptionMethod)
                : base(pollingFrequencySeconds)
            {
                this.actionMethod = actionMethod;
                this.exceptionMethod = exceptionMethod;
            }
            
            #endregion
    
            #region Protected Methods
    
            protected override void Process()
            {
                while (IsRunning)
                {
                    try
                    {
                        actionMethod.Invoke();
                    }
    
                    catch (Exception ex)
                    {
                        exceptionMethod.Invoke(ex);
                    }
    
                    Thread.Sleep(PollingFrequencySeconds * 1000);
                }
            }
    
            #endregion
        }

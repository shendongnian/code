         namespace UITimer
       
    
         {
            using thread = System.Threading;
            public class Timer
            {
            
            public event Action<thread::SynchronizationContext> TaskAsyncTick;
            public event Action Tick;
            public event Action AsyncTick;
            public int Interval { get; set; } = 1;
            private bool canceled = false;
            private bool canceling = false;
            public async void Start()
            {
                while(true)
                {
    
                    if (!canceled)
                    {
                        if (!canceling)
                        {
                            await Task.Delay(Interval);
                            Tick.Invoke();
                        }
                    }
                    else
                    {
                        canceled = false;
                        break;
                    }
                }
    
    
            }
            public void Resume()
            {
                canceling = false;
            }
            public void Cancel()
            {
                canceling = true;
            }
            public async void StartAsyncTask(thread::SynchronizationContext 
            context)
            {
              
                    while (true)
                    {
                        if (!canceled)
                        {
                        if (!canceling)
                        {
                            await Task.Delay(Interval).ConfigureAwait(false);
    
                            TaskAsyncTick.Invoke(context);
                        }
                        }
                        else
                        {
                            canceled = false;
                            break;
                        }
                    }
               
            }
            public void StartAsync()
            {
                thread::ThreadPool.QueueUserWorkItem((x) =>
                {
                    while (true)
                    {
    
                        if (!canceled)
                        {
                            if (!canceling)
                            {
                                thread::Thread.Sleep(Interval);
                                
                        Application.Current.Dispatcher.Invoke(AsyncTick);
                            }
                        }
                        else
                        {
                            canceled = false;
                            break;
                        }
                    }
                });
            }
    
            public void StartAsync(thread::SynchronizationContext context)
            {
                thread::ThreadPool.QueueUserWorkItem((x) =>
                {
                    while(true)
                     {
    
                        if (!canceled)
                        {
                            if (!canceling)
                            {
                                thread::Thread.Sleep(Interval);
                                context.Post((xfail) => { AsyncTick.Invoke(); }, null);
                            }
                        }
                        else
                        {
                            canceled = false;
                            break;
                        }
                    }
                });
            }
            public void Abort()
            {
                canceled = true;
            }
        }
    
    
         }

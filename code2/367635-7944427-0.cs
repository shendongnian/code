     new Thread(() =>
                {
                    Dispatcher.CurrentDispatcher.UnhandledExceptionFilter += Dispatcher_UnhandledExceptionFilter;
                     Dispatcher.Invoke(new Action(()=>doer()));
                }).Start();

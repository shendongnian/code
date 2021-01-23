    public static void DelayAction<T>(
                this Action<T> delayedAction, 
                T argument, 
                int millisecondDelay, 
                CancellationToken cancellationToken)
            {
                // Timeout.Infinite to disable periodic signaling.
                var timer = new System.Threading.Timer(x =>
                                    {
                                       cancellationToken.ThrowIfCancellationRequested();
                                       delayedAction.Invoke(argument);
                                    }, 
                                    null, 
                                    millisecondDelay, 
                                    Timeout.Infinite);                        
            }  

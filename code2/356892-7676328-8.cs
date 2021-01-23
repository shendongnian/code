    public void Intercept(IInvocation invocation)
        {
            using (TimedLock.Lock(monitor))
            {
                state.ProtectedCodeIsAboutToBeCalled(); /* only throws an exception when state is Open, otherwise, it doesn't do anything. */
            }
     
            try
            {
                invocation.Proceed(); /* tells the interceptor to call the 'actual' method for the class that's being proxied.*/
            }
            catch (Exception e)
            {
                using (TimedLock.Lock(monitor))
                {
                    failures++; /* increments the shared error count */
                    state.ActUponException(e); /* only implemented in the ClosedState class, so it changes the state to Open if the error count is at it's threshold. */ 
                }
                throw;
            }
     
            using (TimedLock.Lock(monitor))
            {
                state.ProtectedCodeHasBeenCalled(); /* only implemented in HalfOpen, if it succeeds the "switch" is thrown in the closed position */
            }
        }

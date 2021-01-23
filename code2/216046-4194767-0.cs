    public class Retrier<TResult> 
    {
        public TResult Try(Func<TResult> func, int maxRetries)
        {
            return TryWithDelay(func, maxRetries, 0);
        }   
     
        public TResult TryWithDelay(Func<TResult> func, int maxRetries, int delayInMilliseconds)
        {
            TResult returnValue = default(TResult);
            int numTries = 0;
            bool succeeded = false;
            while (numTries < maxRetries)
            {
                try
                {
                    returnValue = func();
                    succeeded = true;
                }
                catch (Exception)
                {
                    //todo: figure out what to do here
                }
                finally
                {
                    numTries++;
                }
                if (succeeded)
                    return returnValue;
                System.Threading.Thread.Sleep(delayInMilliseconds);
            }
            return default(TResult);
        }
    }

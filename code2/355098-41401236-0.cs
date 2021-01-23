    public static T ExecuteMultipleAttempts<T>(Func<T> inputMethod, Action additionalTask, int wait, int numOfTimes)
            {
                var funcResult = default(T);
                int counter = 0;
                while (counter < numOfTimes)
                {
                    try
                    {
                        counter++;
                        funcResult = inputMethod();
    
                        //If no exception so far, the next line will break the loop.
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (counter >= numOfTimes)
                        {
                            //If already exceeded the number of attemps, throw exception
                            throw;
                        }
                        else
                        {
                            Thread.Sleep(wait);
                        }
    
                        if (additionalTask != null)
                        {
                            additionalTask();
                        }
                    }
                }
    
                return funcResult;
            }

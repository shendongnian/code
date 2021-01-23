    public void MoveNext()
    {
        int returnValue;
        try
        {
            int num3 = state;
            if (num3 == 1)
            {
                goto Label_ContinuationPoint;
            }
            if (state == -1)
            {
                return;
            }
            t = new SimpleAwaitable();
            i = 0;
          Label_ContinuationPoint:
            while (i < 3)
            {
                // Label_ContinuationPoint: should be here
                try
                {
                    num3 = state;
                    if (num3 != 1)
                    {
                        Console.WriteLine("In Try");
                        awaiter = t.GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            state = 1;
                            awaiter.OnCompleted(MoveNextDelegate);
                            return;
                        }
                    }
                    else
                    {
                        state = 0;
                    }
                    int result = awaiter.GetResult();
                    awaiter = null;
                    returnValue = result;
                    goto Label_ReturnStatement;
                }
                catch (Exception)
                {
                    Console.WriteLine("Trying again...");
                }
                i++;
            }
            returnValue = 0;
        }
        catch (Exception exception)
        {
            state = -1;
            Builder.SetException(exception);
            return;
        }
      Label_ReturnStatement:
        state = -1;
        Builder.SetResult(returnValue);
    }

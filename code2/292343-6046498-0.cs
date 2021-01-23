    void DoStuff<T1, T2, TResult>(Func<T1, T2, TResult> myMethod, T1 arg1, T2 arg2)
    {
            try
            {
                myMethod(arg1, arg2)
            }
            catch (FaultException<CustomException> cfex)
            {
                // common stuff
            }
            catch (CustomException cfex)
            {
                // common stuff
            }
            catch (Exception ex)
            {
                // common stuff
            }
            finally
            {
                FinalizeServiceCall(wsBus, wsMessage, response, logProps);
            }
    }

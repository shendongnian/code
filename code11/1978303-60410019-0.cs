    SafeCall(()=> call_external_cpp_function());
    [HandleProcessCorruptedStateExceptions]
    [SecurityCritical]
    internal static void SafeCall(Action action)
    {
        try
        {
            action();
        }
        catch (System.Threading.ThreadAbortException) { throw; }
        catch (System.Threading.ThreadInterruptedException) { throw; }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

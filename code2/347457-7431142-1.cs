    try
    {
    }
    catch(LoggerException ex)
    {
        ex.WriteLog();
    }
    // no more classes is allowed by the compiler be here, only interfaces in a tail catch recursion
    catch(ILoggerException1 ex1)
    {
        ex1.WriteLog();
    }
    catch(ILoggerException2 ex2)
    {
        ex2.WriteLog();
    }
    catch(ILoggerException3 ex3)
    {
        ex3.WriteLog();
    }

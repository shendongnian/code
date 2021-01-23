    try
    {
    }
    catch(LoggerException ex) 
    { 
        ex.WriteLog(); 
    } 
    catch(Exception ex)
    {
        ILoggerException1 l1 = ex as ILoggerException1; 
        if (l1 != null)
        {
            l1.WriteLog1();
        }
        else
        {
            ILoggerException2 l2 = ex as ILoggerException2; 
            if (l2 != null)
            {
                l2.WriteLog2();
            }
            else
            {
                ILoggerException3 l3 = ex as ILoggerException3; 
                if (l3 != null)
                {
                    l3.WriteLog3();
                }
                else
                {
                    throw ex;
                }
            }
        }
    }

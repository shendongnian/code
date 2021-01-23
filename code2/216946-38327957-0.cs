        static void CallAndThrow()
        {
            throw new ApplicationException("Test app ex", new Exception("Test inner ex"));
        }
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    try
                    {
                        CallAndThrow();
                    }
                    catch (Exception ex)
                    {
                        var dispatchException = ExceptionDispatchInfo.Capture(ex);
                        // rollback tran, etc
                        dispatchException.Throw();
                    }
                }
                catch (Exception ex)
                {
                    var dispatchException = ExceptionDispatchInfo.Capture(ex);
                    // other rollbacks
                    dispatchException.Throw();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }

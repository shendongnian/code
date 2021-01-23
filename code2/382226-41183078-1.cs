        static void A()
        {
            try
            {
                throw new Exception("A");
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
            }
        }

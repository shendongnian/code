        public void
        CallbackMethod
            (IAsyncResult AR)
        {
            // Retrieve the delegate
            MyDelegate ThisDelegate =
                (MyDelegate)AR.AsyncState;
            try
            {
                Int32 Ret = ThisDelegate.EndInvoke(AR);
            } // End try
            catch (Exception Ex)
            {
                ReportException(Ex);
            } // End try/catch
        } // End CallbackMethod

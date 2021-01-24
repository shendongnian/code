        public static Object HostContext
        {
            [System.Security.SecurityCritical]  // auto-generated
            get
            {
                ExecutionContext.Reader ec = Thread.CurrentThread.GetExecutionContextReader();
 
                Object hC = ec.IllogicalCallContext.HostContext;
                if (hC == null)
                    hC = ec.LogicalCallContext.HostContext;
                return hC;
            }

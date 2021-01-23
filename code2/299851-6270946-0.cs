    using System;
    using System.EnterpriseServices;
    using System.Runtime.InteropServices;
    
    namespace ClassLibrary1
    {
        [ComVisible(true)]
        [EventTrackingEnabled(true)]
        [JustInTimeActivation(true)]
        [ObjectPooling(CreationTimeout=60000, 
                       Enabled=true, MaxPoolSize=1, MinPoolSize=0)]
        public class Class1 : ServicedComponent
        {
            public Class1()
            {
            }
    
            public string Hello()
            {
                System.Diagnostics.Trace.TraceInformation("Call Hello");
                // We are done after this call so return this instance to the pool
                ContextUtil.DeactivateOnReturn = true;
    
                return "world";
            }
    
            // Get an instance from the pool
            protected override void Activate()
            {
                System.Diagnostics.Trace.TraceInformation("Activated");
                base.Activate();
            }
    
            // Return an instance to the pool
            protected override void Deactivate()
            {
                System.Diagnostics.Trace.TraceInformation("Deactivate");
                base.Deactivate();
            }
    
            // Runtime will call Dispose after method call (with disposing = true)
            protected override void Dispose(bool disposing)
            {
                System.Diagnostics.Trace.TraceInformation("Disposing = " + disposing);
                base.Dispose(disposing);
            }
    
        }
    }

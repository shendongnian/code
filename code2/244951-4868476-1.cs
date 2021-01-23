    [Serializable]
    public class TraceAttribute : OnMethodBoundaryAspect
    {
    
        public override void OnEntry( MethodExecutionArgs args )
        {
            Trace.WriteLine("about to call method");
        }
    
        public override void OnExit(MethodExecutionArgs args) 
        { 
           Trace.WriteLine("just finished calling method"); 
        }
     }

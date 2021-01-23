    [Serializable]
    public class TraceAttribute : OnMethodBoundaryAspect
    {
    
        public override void OnEntry( MethodExecutionArgs args )
        {
            Trace.TraceInformation("Before");
        }
    
        public override void OnExit(MethodExecutionArgs args) 
        { 
           Trace.WriteLine(string.Format("After"); 
        }
     }

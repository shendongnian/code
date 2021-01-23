    public class MyValidationAspect : OnMethodBoundaryAspect
    {
    
    public int Val1 { get; set; }
    public int Val2 { get; set; }
    
    public override void OnExit(MethodExecutionArgs args) 
        { 
            if (this.args.Arguments[0] > Val1) // If-statment from string, this is the problem... 
            { ... } 
        } 
    
    
    }
    [MyValidationAspect(Val1 = 5, Val2 = ...)]

    [Serializable]
    public class MyAspectAttribute : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
             ExprParser parser = new ExprParser();
             LambdaExpression lambda = parser.Parse(/* Verify string comes here */);
             bool isConditionMet = (bool) parser.Run(lambda, this);
             if (isConditionMet)
             { ... }
        }
    }

    [Serializable]
    public class MyAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            string input = (string)args.Arguments[0];
    
            if (input.Equals("123"))
            {
                args.Arguments.SetArgument(0, " 456");
            }
    
            args.Proceed();
        }       
    }

    [Serializable]
        public class MyAspect : MethodInterceptionAspect
        {
            public override void OnInvoke(MethodInterceptionArgs args)
            {
                args.Arguments.SetArgument(0, "test");
                args.Proceed();
            }
    
           
        }

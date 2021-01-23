    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
            Console.WriteLine(String.Format("{0}.{1}: {2}",
                args.Method.DeclaringType.Name,
                args.Method.Name,
                args.ReturnValue));
        }
    }

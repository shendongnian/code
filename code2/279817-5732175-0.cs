    [Serializable]
        [MulticastAttributeUsage(MulticastTargets.Method, Inheritance=MulticastInheritance.Strict)]
        public class LogAspect : OnMethodBoundaryAspect
        {
            public override void OnEntry(MethodExecutionArgs args)
            {
                var Logger = Unity.Resolve<T>();
                Logger.Write(args.Method.Name + " enter");
            }
    
            public override void OnExit(MethodExecutionArgs args)
            {
                var Logger = Unity.Resolve<T>();
                Logger.Write(args.Method.Name + " exit");
            }
        }

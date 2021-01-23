	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	[MulticastAttributeUsage(
		MulticastTargets.Method,
		Inheritance = MulticastInheritance.Multicast,
		AllowMultiple = false)]
         public sealed class ErrorHandlingAttribute : OnMethodBoundaryAspect
         {
             public override void OnException(MethodExecutionArgs args)
             {
                 base.OnException(args);
                 Exception ex = args.Exception;
                 AggregateException ae;
                 if ((ae = ex as AggregateException) !=null)
                     ex = ae.InnerExceptions[0];
                 // your error handling logic
             }
         }

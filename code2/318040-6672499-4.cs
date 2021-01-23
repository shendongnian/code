    [Serializable]
	public class LogMethodCallAttribute : OnMethodBoundaryAspect
	{
        public Type FilterAttributeType { get; set; }
        public LogMethodCallAttribute(Type filterAttributeType)
        {
            FilterAttributeType = filterAttributeType;
        }
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
		{
            if (!Proceed(eventArgs)) return;
			Console.WriteLine(GetMethodName(eventArgs));
		}
		public override void OnException(MethodExecutionEventArgs eventArgs)
		{
            if (!Proceed(eventArgs)) return;
			Console.WriteLine(string.Format("Exception at {0}:\n{1}", 
					GetMethodName(eventArgs), eventArgs.Exception));
		}
        public override void OnExit(MethodExecutionEventArgs eventArgs)
        {
            if (!Proceed(eventArgs)) return;
             Console.WriteLine(string.Format("{0} returned {1}", 
                    GetMethodName(eventArgs), eventArgs.ReturnValue));
        }
        private string GetMethodName(MethodExecutionEventArgs eventArgs)
        {
            return string.Format("{0}.{1}", eventArgs.Method.DeclaringType, eventArgs.Method.Name);
        }
        private bool Proceed(MethodExecutionEventArgs eventArgs)
        {
             return Attribute.GetCustomAttributes(eventArgs.Method, FilterAttributeType).Length == 0;
        }
	}

    [Serializable]
	public class LogMethodCallAttribute : OnMethodBoundaryAspect
	{
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
		{
			Console.WriteLine(GetMethodName(eventArgs));
		}
		public override void OnException(MethodExecutionEventArgs eventArgs)
		{
			Console.WriteLine(string.Format("Exception at {0}:\n{1}", 
					GetMethodName(eventArgs), eventArgs.Exception));
		}
        public override void OnExit(MethodExecutionEventArgs eventArgs)
        {
             Console.WriteLine(string.Format("{0} returned {1}", 
                    GetMethodName(eventArgs), eventArgs.ReturnValue));
        }
        private string GetMethodName(MethodExecutionEventArgs eventArgs)
        {
            return string.Format("{0}.{1}", eventArgs.Method.DeclaringType, eventArgs.Method.Name);
        }
	}

    public class MyTask : Task
    {
		public Guid Identifire;
	
		public MyTask(Action action, Guid identifire) : base(action)
		{
			Identifire = identifire;
		}
	
		public MyTask(Action action, CancellationToken cancellationToken, Guid identifire) : base(action, cancellationToken)
		{
			Identifire = identifire;
		}
	
		public MyTask(Action action, TaskCreationOptions creationOptions, Guid identifire) : base(action, creationOptions)
		{
			Identifire = identifire;
		}
	
		public MyTask(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions, Guid identifire) : base(action, cancellationToken, creationOptions)
		{
			Identifire = identifire;
		}
	
		public MyTask(Action<object> action, object state, Guid identifire) : base(action, state)
		{
			Identifire = identifire;
		}
	
		public MyTask(Action<object> action, object state, CancellationToken cancellationToken, Guid identifire) : base(action, state, cancellationToken)
		{
			Identifire = identifire;
		}
	
		public MyTask(Action<object> action, object state, TaskCreationOptions creationOptions, Guid identifire) : base(action, state, creationOptions)
		{
			Identifire = identifire;
		}
	
		public MyTask(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, Guid identifire) : base(action, state, cancellationToken, creationOptions)
		{
			Identifire = identifire;
		}
		
	
	}

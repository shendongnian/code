	public class RetryOnTimeout : ICommand
	{
		private readonly ICommand command;
		private int numberOfRetries;
		public RetryOnTimeout(ICommand command, int numberOfRetries)
		{
			this.command = command;
			this.numberOfRetries = numberOfRetries;
		}
		public void Execute()
		{
			try
			{
				command.Execute();
			}
			catch (TimeoutException)
			{
				if (++numberOfRetries > 3)
					throw;
				Execute();
			}
		}
	}

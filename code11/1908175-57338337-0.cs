	public class Service
	{
		private Task _job;
		private CancellationTokenSource _cancellationTokenSource;
		private readonly System.Timers.Timer _timer;
		public Service()
		{
			_timer = new System.Timers.Timer();
			{
				_timer.AutoReset = false;
				_timer.Interval = TimeSpan.FromSeconds(5).TotalMilliseconds;    
				_timer.Elapsed += OnElapsedTime;
			}
		}
		public void Start()
		{
			Console.WriteLine("Starting service");
			_timer.Start();
		}
		private void OnElapsedTime(object source, ElapsedEventArgs e)
		{
			Console.WriteLine("OnElapsedTime");
			if (_job != null)
			{
				CancelAndWaitForPreviousJob();
			}
			Console.WriteLine("Starting new job");
			_cancellationTokenSource = new CancellationTokenSource();
			_job = Task.Run(
				() => ExecuteJob(_cancellationTokenSource.Token), 
				_cancellationTokenSource.Token);
			_timer.Start();
		}
		private void CancelAndWaitForPreviousJob()
		{               
			 _cancellationTokenSource.Cancel();   
			try
			{
				Console.WriteLine("Waiting for job to complete");
				_job.Wait(
					millisecondsTimeout: 5000); // Add additional timeout handling?  
			}                
			catch (OperationCanceledException canceledExc)
			{
				Console.WriteLine($"Cancelled the execution: {canceledExc}");
			}     
			catch (Exception exc) 
			{                    
				Console.WriteLine($"Some unexpected exception occurred - ignoring: {exc}");
			}
		}
		private void ExecuteJob(CancellationToken cancellationToken)
		{
			Console.WriteLine("ExecuteJob start");
			try
			{
				for (var i = 0; i < 10; i++)
				{
					Console.WriteLine($"Job loop Iteration {i}");
					if (cancellationToken.IsCancellationRequested)
					{
						Console.WriteLine("Cancellation requested - ending ExecuteJob");
						return;
					}
					Thread.Sleep(1000);
				}
			}
			finally
			{
				Console.WriteLine("ExecuteJob end");
			}
		}
	}

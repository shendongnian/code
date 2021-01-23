	interface IProgress
	{
		event EventHandler ProgressChanged;
		int ProgressTarget { get; }
		int CurrentProgress { get; }
	}

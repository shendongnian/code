	public class MyClass
	{
		public event ProgressChangedEventHandler ProgressChanged;
		protected virtual void OnProgressChanged(int progress)
		{
			if (ProgressChanged!= null)
			{
				ProgressChanged(this, new ProgressChangedEventArgs(progress, null));
			}
		}
		public int ComputeFibonacci(int input)
		{
			//<Calculate stuff>
			OnProgressChanged(currentProgress);
			//...
			return output;
		}
	}

	public class Task : INotifyPropertyChanged
	{
		private int _progress = 0;
		public int Progress
		{
			get { return _progress; }
			private set
			{
				if (_progress != value)
				{
					_progress = value;
					OnPropertyChanged("Progress");
				}
			}
		}
		public Task(ref ProgressChangedEventHandler progressChangedEvent)
		{
			progressChangedEvent += (s, e) => Progress = e.ProgressPercentage;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

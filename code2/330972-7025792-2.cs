	public class MyData : INotifyPropertyChanged
	{
		private bool _ACondition = false;
		public bool ACondition
		{
			get { return _ACondition; }
			set
			{
				if (_ACondition != value)
				{
					_ACondition = value;
					OnPropertyChanged("ACondition");
				}
			}
		}
		//...
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

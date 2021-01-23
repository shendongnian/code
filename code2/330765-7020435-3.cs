<!-- -->
	class MyClass : INotifyPropertyChanged
	{
		private bool _IsSelected = false;
		public bool IsSelected
		{
			get { return _IsSelected; }
			set
			{
				if (_IsSelected != value)
				{
					_IsSelected = value;
					OnPropertyChanged("IsSelected");
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

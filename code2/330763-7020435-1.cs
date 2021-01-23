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
					PropertyChanged.Notify(() => this.IsSelected);
				}
			}
		}
		//...
	}

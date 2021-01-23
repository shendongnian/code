    public class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			var safePropertyChanged = this.PropertyChanged;
			if (safePropertyChanged != null)
			{
				safePropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}			
		}
	}

    public class MyViewModel : INotifyPropertyChanged  
	{  
		public event PropertyChangedEventHandler PropertyChanged;  
		// This method is called by the Set accessor of each property.  
		// The CallerMemberName attribute that is applied to the optional propertyName  
		// parameter causes the property name of the caller to be substituted as an argument.  
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
		{  
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}  
		private int _cidadeSelectedIndex;
		
		public int CidadeSelectedIndex
		{
			get => _cidadeSelectedIndex;
			set {
				_cidadeSelectedIndex = value;
				NotifyPropertyChanged();
			}
		}
	}  

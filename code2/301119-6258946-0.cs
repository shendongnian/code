	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		//For simplicity in put everything in the Window rather than models and view-models
		public enum TestEnum { Ichi, Ni, San }
		private TestEnum _EnumValue;
		public TestEnum EnumValue
		{
			get { return _EnumValue; }
			set
			{
				if (_EnumValue != value)
				{
					_EnumValue = value;
					PropertyChanged.Notify(() => this.EnumValue);
				}
			}
		}
		
		//...
	}

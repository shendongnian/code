    class MainWindowViewModel : INotifyPropertyChanged
	{
		private int _sliderValue;
		public int SliderValue
		{
			get
			{
				return _sliderValue;
			}
			set
			{
				_sliderValue = value;
				while ( SliderValue > CheckboxValues.Count )
				{
					CheckboxValues.Add( false );
				}
				// remove bools from the CheckboxValues while SliderValue < CheckboxValues.Count
				// ...
			}
		}
		private ObservableCollection<Boolean> _checkboxValues = new ObservableCollection<Boolean>();
		public ObservableCollection<Boolean> CheckboxValues
		{
			get
			{
				return _checkboxValues;
			}
			set
			{
				if ( _checkboxValues != value )
				{
					_checkboxValues = value;
					RaisePropertyChanged( "CheckboxValues" );
				}
			}
		}

    class MainWindowViewModel : INotifyPropertyChanged
	{		
		ObservableCollection<Company> _company;
		public ObservableCollection<Company> Company
		{
			get
			{
				return _company;
			}
			set
			{
				if ( _company != value )
				{
					_company = value;
					RaisePropertyChanged( "Company" );
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged( string name )
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if ( handler != null ) handler( this, new PropertyChangedEventArgs( name ) );
		}

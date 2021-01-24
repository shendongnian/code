	private Type1ViewModel _type1ViewModel;
	public Type1ViewModel Type1ViewModel
	{
		get { return _type1ViewModel; }
		set
		{
			if (_type1ViewModel != value)
			{
				_type1ViewModel = value;
				NotifyPropertyChanged();
			}
		}
	}
	private Type2ViewModel _type2ViewModel;
	public Type2ViewModel Type2ViewModel
	{
		get { return _type2ViewModel; }
		set
		{
			if (_type2ViewModel != value)
			{
				_type2ViewModel = value;
				NotifyPropertyChanged();
			}
		}
	}
	
	...
	
	private ObservableObject _mainContent;
	public ObservableObject MainContent
	{
		get { return _mainContent; }
		set
		{
			if (_mainContent != value)
			{
				_mainContent = value;
				NotifyPropertyChanged();
			}
		}
	}
	
	...
	
	public InternalDelegateCommand NavigateToType1Command => new InternalDelegateCommand(NavigateToType1);
	public InternalDelegateCommand NavigateToType2Command => new InternalDelegateCommand(NavigateToType2);
	
	...
	
	private void NavigateToType1() => MainContent = Type1ViewModel;
	private void NavigateToType2() => MainContent = Type2ViewModel;
	

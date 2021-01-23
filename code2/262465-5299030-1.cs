	public RelayCommand<string> myCommand { get; private set; }
	myCommand = new RelayCommand<string>((s) => Test(s));
	private void Test(string s)
	{
		throw new NotImplementedException();
	}

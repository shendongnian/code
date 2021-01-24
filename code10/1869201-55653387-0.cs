    private string _filename;
	public BitmapImage ImageData
	{
		get;set;
	}
	public string FileName
	{
		get
		{
			return _filename;
		}
		set
		{
			if (_filename != value)
			{
				_filename = value;
                OnPropertyChanged(nameof(FileName));
			}
		}
	}

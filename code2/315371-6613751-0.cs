    string _Title;
    public string Title
    {
        get
        {
            if (_Title == null)
            {   
                DispatcherHelper.UIDispatcher.InvokeAsync(async () => { Title = await getTitle(); });
            }
            return _Title;
        }
        set
        {
            if (value != _Title)
            {
                _Title = value;
                RaisePropertyChanged();
            }
        }
    }

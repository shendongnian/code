    public event EventHandler<LazyLoadEventArgs> LazyLoadData;
    public ObservableCollection<PhoneNumberModel> PhoneNumbers
    {
        get
        {
            if (_phoneNumbers == null)
            {
                LazyLoadEventArgs args = new LazyLoadEventArgs();
                LazyLoadData(this, args);
                if (args.Data != null)
                   this._phoneNumbers = args.Data as ObservableCollection<PhoneNumberModel>;
            }
            return _phoneNumbers;
        }
    }

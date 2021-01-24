    public Record _record{ get; set; }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _record = new Record();
        string myValue = Preferences.Get("my_File_Path", "default_value");
        _record.ImageFile = myValue;
        BindingContext = _record;
    }

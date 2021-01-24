    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (Application.Current.Properties.ContainsKey("value"))
        {
            var ValueGet = Application.Current.Properties ["value"] as DataType;
            // do something with other things
        }
    }

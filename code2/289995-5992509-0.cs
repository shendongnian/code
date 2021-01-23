    private CustomObject myObject;
    protected override void OnNavigatedFrom(NavigationEventArgs args)
    {
        //Save to State when leaving the page
        PhoneApplicationService.Current.State["myObject"] = myObject;
        base.OnNavigatedFrom(args);
    }
    protected override void OnNavigatedTo(NavigationEventArgs args)
    {
        if (PhoneApplicationService.Current.State.ContainsKey("myObject"))
        {
            //Restore from State
            myObject = (CustomObject)PhoneApplicationService.Current.State["myObject"];
        }
        else
        {
            //No previous object, so perform initialization
            myObject = new myObject();
        }
    }

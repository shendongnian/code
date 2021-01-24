    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // This will trigger behavior cleanup
        // MyListView.ItemsSource = null;
        this.BindingContext = null;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        //MyListView.ItemsSource = list; //in the page constructor in the sample above
        // bind your viewmodel (set the BindingContext)
        ...
    }

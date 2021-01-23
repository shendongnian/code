    for (int i = 0; i < App.Accounts.Items.Count; i++)
    {
        PivotItem pvItem = new PivotItem();
        pvItem.Header = App.Accounts.Items[i].Username;
        
        //instantiate your control and set the DataContext/ItemsSource to your model it will be bound to
        MyUserControl myControl = new MyUserControl();
        myControl.DataContext = someModel;
        myControl.List.ItemsSource = someModel.List;
        
        //assign content to the instance of your user control
        pvItem.Content = myControl;         
        pivotControl.Items.Add(pvItem);
    }

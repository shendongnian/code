    void LoadUI()
    {
        using( var db = new TestDataContext() )
        {
            // use DataLoadOptions.LoadWith<T> if we need 
            // access to foreign key/ deferred objects.
            masterGrid.ItemsSource = db.Customers.ToList();
            detailsGrid.ItemsSource = // this is always set to a collection of Settings
                                      // for the currently selected user in masterGrid.
                                      // just a simple foreign key relationship
        }
    }
    
    void UpdateName( string newName )
    {
        using( var db = new TestDataContext() )
        {
            var customer = ((Customer)masterGrid.SelectedItem);
            var freshLoadedCustomer = db.Customers.FirstOrDefault(cust=>cust.Id == customer.Id);
            if(freshLoadedCustomer != null)
            { freshLoadedCustomer.Name = newName; db.SubmitChanges();}
        }
    }

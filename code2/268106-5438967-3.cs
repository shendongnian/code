    int startId = GetSomeIDToStartWith();
    Foo myFoo = new Foo();
    myFoo.FetchItems(startId).Run((err) =>
    {
        // Clear IsBusy
        if (err == null)
        {
            // All items are now fetched continue doing stuff here.
           
        }
        else
        {
            // "Oops something bad happened" code here
        }
    }
    // Set IsBusy 

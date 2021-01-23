    public void DoSomething (ref DetailsViewInsertedEventArgs args)
    {
      DoCommonStuff (args);
      // do something with a DetailsViewInsertedEventArgs exception
    }
    public void DoSomething (ref DetailsViewDeletedEventArgs args)
    {
      DoCommonStuff (args);
      // something with a DetailsViewDeletedEventArgs exception
    }
    public void DoSomething (ref DetailsViewUpdatedEventArgs args)
    {
      DoCommonStuff (args);
      // do something with a DetailsViewUpdatedEventArgs exception
    }
    void DoCommonStuff (ref CommonAncestorForDVArgs args)
    {
      // common stuff
    }

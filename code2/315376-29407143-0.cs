    private IEnumerable myList;
    public IEnumerable MyList
    {
      get
        { 
          if(myList == null)
             InitializeMyList();
          return myList;
         }
      set
         {
            myList = value;
            NotifyPropertyChanged();
         }
    }
    public async void InitializeMyList()
    {
       MyList = await AzureService.GetMyList();
    }

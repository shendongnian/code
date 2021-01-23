    public Items[] GetItems(string searchString)
    {
      if (searchString.Length < 4)
      {
        return _cacheDataProvider.GetItems(searchString);
      }
      
      return _mySqlDataProvider.GetItems(searchString);
    }
    
    public void UpdateItem(Item itemToBeUpdated)
    {
      _cacheDataProvider.UpdateItem(itemToBeUpdated);
      _mySqlDataProvider.UpdateItem(itemToBeUpdated);
    }

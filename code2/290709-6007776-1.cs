    private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
    {
           //different kind of changes that may have occurred in collection
           if(e.Action == NotifyCollectionChangedAction.Add)
            {
                //your code
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                //your code
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                //your code
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                //your code
            }
    }

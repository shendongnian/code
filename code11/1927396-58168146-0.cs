    internal CollectionView(IEnumerable collection, int moveToFirst)
    {
    ...
    	object currentItem = null;
    	int currentPosition = -1;
    	if (moveToFirst >= 0)
	    {
	    	BindingOperations.AccessCollection(collection, delegate
    		{
	    		IEnumerator enumerator = collection.GetEnumerator();
    			if (enumerator.MoveNext())
    			{
    				currentItem = enumerator.Current;
    				currentPosition = 0;
    			}
    			(enumerator as IDisposable)?.Dispose();
    		}, writeAccess: false);
    	}
    	_currentItem = currentItem;
    	_currentPosition = currentPosition;
    ...
    }

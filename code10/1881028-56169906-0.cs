    public class MyViewModel : INotifyPropertyChanged
    {
        //TODO implement INotifyPropertyChanged
    	public MyViewModel()
    	{
    		Init();
    	}
    	
    	private ICollectionView _listResult;
    	public ICollectionView ListResult
    	{
    		get => _listResult;
    		set
    		{
    			if (Equals(value, _listResult)) return;
    			_listResult = value;
    			OnPropertyChanged();
    		}
    	}
    
    	private void Init(){    		
    		var results = new List<ResultVm>(){....};
    		
    		ListResult = new CollectionView(results);
    
    		// Event when another item gets selected
    		ListResult.CurrentChanged += ListResultOnCurrentChanged;
    
    		// moves selected index to postion 2
    		ListResult.MoveCurrentToPosition(2); 
    	}
    
    	private void ListResultOnCurrentChanged(object sender, EventArgs e)
    	{
    		// the currently selected item
    		ResultVm resultVm = (ResultVm)ListResult.CurrentItem;
    
    		// the currently selected index
    		int currentIndex = ListResult.CurrentPosition;
    	}
    }

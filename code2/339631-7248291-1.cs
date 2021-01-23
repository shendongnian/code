    IEnumerable<MyEnityType> Model {get;set;}
    //NOTE: add notify property changed in setter!
        
    private void GetData()
    {
        _myDataService.GetData( _filter, loadOperation =>
    			{
    				if ( loadOperation.HasError )
    					HandleError(loadOperation.Error);    
    				Model = loadOperation.Entities;
    			} );
    }

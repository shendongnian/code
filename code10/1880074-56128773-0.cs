    List<PersonVm> personVms;
    private ICollectionView _persons;
    public ICollectionView Persons
    {
    	get => _persons;
    	set
    	{
    		if (Equals(value, _persons)) return;
    		_persons = value;
    		OnPropertyChanged();
    	}
    }
    
    // call this method in the constructor of the viewmodel
    private void Init(){
    	// TODO You have to add items to personVms before creating the collection
    	        
    	Persons = new CollectionView(personVms);
        
        // Event when another item gets selected
    	Persons.CurrentChanged += PersonsOnCurrentChanged;
        // moves selected index to postion 2
    	Persons.MoveCurrentToPosition(2); 
    }
    
    private void PersonsOnCurrentChanged(object sender, EventArgs e)
    {
    	// the currently selected item
    	PersonVm personVm = (PersonVm)Persons.CurrentItem;
    	
    	// the currently selected index
    	int personsCurrentPosition = Persons.CurrentPosition;
    }

    private ObservableCollection<SubViewModel> _result = new ObservableCollection<SubViewModel>();
    public ObservableCollection Result    
    {
        get
        {
            return _result;
        }        
        set
        {
            _result = value;
            NotifyPropertyChanged("Result");
        }
    }
    // -- elsewhere --
    private void processResult<E>(E element)    
    {        
        // (why were you using the type **name** to check the 
        // type of the result instead of just using `as`?)
        var model = element as MyViewModel;
        if (model != null)
        {              
            App.ViewModel.Result = model.result;              
        }    
    }

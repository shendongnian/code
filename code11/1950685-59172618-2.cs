    public class SourceViewModel:INotifyPropertyChanged
    {
    	public SourceViewModel (List<ValueViewModel> list)
    	{
    		SelectValueCommand = new Command<ValueViewModel>((value) => ExecuteSelectValueCommand(value), (value)=>!IsBusy);
    	}
    	
    	private ObservableCollection<ValueViewModel> _values = new ObservableCollection<ValueViewModel>();
    	private bool _isSelected;
    	private sring _description;
    	
    	public ICommand SelectValueCommand;
    	public bool IsBusy{get;set;}
    	
    	public ObservableCollection<ValueViewModel> Values 
    	{
    		get=>_values;
    		set
    		{
    			_values = value;
    			OnPropertyChanged(nameof(Values));
    		}
    	}
    	
    	public void ExecuteSelectValueCommand(ValueViewModel value)
    	{
    		if(IsBusy) return;
    		
    		item.IsSelected = CanValueBeSelected(value);		
    	}
    	
    	private bool CanValueBeSelected(ValueViewModel value)
    	{
    		var result = false;
    		
    		//Some logic to determine if it can be selected
    		
    		return result;
    	}
    	#region INotifyPropertyChanged implementation
    	// ...
    	#endregion	
    }
    public class ValueViewModel:INotifyPropertyChanged
    {
    	public ValueViewModel (string description, int value)
    	{
    		Description = description;
    		Value = value;
    	}
    	
    	private int _value;
    	private bool _isSelected;
    	private sring _description;
    	
    	public int Value
    	{
    		get=>_value;
    		set
    		{
    			_value=value;
    			OnPropertyChanged(nameof(Value));
    		}
    	}
    	
    	public bool IsSelected
    	{
    		get=> _isSelected;
    		set
    		{
    			_isSelected= value;
    			OnPropertyChanged(nameof(IsSelected));
    		}
    	}
    	
    	public string Description
    	{
    		get=> _description;
    		set
    		{
    			_description= value;
    			OnPropertyChanged(nameof(Description));
    		}
    	}
    	#region INotifyPropertyChanged implementation
    	// ...
    	#endregion	
    }

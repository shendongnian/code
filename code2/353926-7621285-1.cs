    public class NodeViewModel
    {
    	public NodeViewModel()
    	{
    		this.AddCommand = new RelayCommand(obj => { /* do something */ });
    	}
    	
    	public RelayCommand AddCommand { get; private set; }
    	//...
    }

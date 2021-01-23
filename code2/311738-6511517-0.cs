    public partial class MainWindow : Window     
    {	 
    	public MainWindow()         
    	{             
    		InitializeComponent();             
    		this.DataContext = new ParentViewModel();             
    	}        
    }  
    
    public class ParentViewModel     
    {
    	public ViewModel()        
    	{ 
    		this.Child = new ChildViewModel();       
    	}         
    
    	public ChildViewModel Child { get; set; }     
    }  
    
    public class ChildViewModel     
    {
    	public ViewModel()        
    	{ 
    		this.SampleText = "Sample";         
    	}         
    
    	public string SampleText { get; set; }     
    }
  

    void Main()
    {
	   var page1 = new Page1();
	   var page2 = new Page2();
	
	   foreach (var txt in ImageList.Instance)
	   {
	    	Console.WriteLine (txt);
            // prints:
            // Instance created
            // page1
            // page2
	   }
    }
    public class ImageList : ObservableCollection<string>
    {
    	private static ImageList _instance;
    	public static ImageList Instance 
    	{ 
    		get
    		{
    			if(_instance==null)
    			{
    				_instance = new ImageList();
    				_instance.Add("Instance created");		
    			}
    			return _instance;
    		}
    	}
    
      	private ImageList() 
  	    {
	    }
    }
    public class Page1
    {
    	public Page1()
    	{
    		ImageList.Instance.Add("page1");
    	}
    }
    
    public class Page2
    {
    	public Page2()
    	{
    		ImageList.Instance.Add("page2");
    	}
    }

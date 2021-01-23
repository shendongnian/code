    public class CustomListView : ListView
    {
    
    	public event EventHandler SizeChanging;
    
    	protected override void OnSizeChanged(System.EventArgs e)
    	{
    		//Raise the SizeChanging event before the ListView's size is changed
    		if (SizeChanging != null) {
    			SizeChanging(this, e);
    		}
    
    		base.OnSizeChanged(e);
    	}
    
    }

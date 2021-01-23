    public class CustomListView : ListView
    {
    
    	protected override void OnSizeChanged(System.EventArgs e)
    	{
    		//Fire my custom method before the ListView's size is changed
    		MyCustomMethod();
    
    		base.OnSizeChanged(e);
    	}
    	private void MyCustomMethod()
    	{
            //Insert your custom logic here
            //...
    	}    
    }

    public partial class MyButton : Button
    {
    	//...
    
    	public string MyStorage
    	{
    		get { return (string)GetValue(MyStorageProperty); }
    		set { SetValue(MyStorageProperty, value); }
    	}
    
    	public static DependecyProperty MyStorageProperty = 
    		DependencyProperty.Register("MyStorage", typeof(string), typeof(MyButton),
    			new UIPropertyMetadata(OnMyStorageChanged));
    	public static void OnMyStorageChanged(DependecyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		var myButton = d as MyButton;
    		if (myButton == null)
    			return;
    		myButton.OnMyStorageChanged(d,e);
    	}
    
    	public void OnMyStorageChanged(object sender, DependencyPropertyChangedEventArgs e)
    	{
    		// ...
    	}
    }

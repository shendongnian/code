    public class BindingProxy : Freezable
    {	
    	public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
    		"Data", typeof (object), typeof (BindingProxy), new UIPropertyMetadata(null));
    
    	/// <summary>
    	///     This Property holds the DataContext
    	/// </summary>
    	public object Data
    	{
    		get { return GetValue(DataProperty); }
    		set { SetValue(DataProperty, value); }
    	}
    
    	protected override Freezable CreateInstanceCore()
    	{
    		return new BindingProxy();
    	}
    }

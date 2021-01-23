    public partial class YourControl
    {
    	public bool Enabled
    	{
    		get	{ return (bool)GetValue(EnabledProperty);	}
    		set	{ SetValue(EnabledProperty, value); }
    	}
    	public static readonly DependencyProperty EnabledProperty =
    		DependencyProperty.Register(nameof(Enabled), typeof(bool), typeof(SomeOtherControl), new PropertyMetadata(false));
    }

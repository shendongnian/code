    xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
    <TextBlock Text="Test" Foreground="Aquamarine">
        <i:Interaction.Behaviors>
            <local:ForwardForegroundOnClick  ForwardedColor="{Binding Background, RelativeSource={RelativeSource AncestorType=Window}, Mode=TwoWay}"/>
        </i:Interaction.Behaviors>
    </TextBlock>
    
    public class ForwardForegroundOnClick : Behavior<TextBlock>
    {
    	public Brush ForwardedColor
    	{
    		get { return (Brush)GetValue(ForwardedColorProperty); }
    		set { SetValue(ForwardedColorProperty, value); }
    	}
    
    	// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    	public static readonly DependencyProperty ForwardedColorProperty =
    		DependencyProperty.Register(nameof(ForwardedColor), typeof(Brush), typeof(ForwardForegroundOnClick), new PropertyMetadata(null));
    
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    		AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
    	}
    
    	private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    	{
    		ForwardedColor = AssociatedObject.Foreground;
    	}
    
    	protected override void OnDetaching()
    	{
    		AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
    
    		base.OnDetaching();
    	}
    }

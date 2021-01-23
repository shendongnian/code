    public class Customer : DependencyObject
    {
    	public Customer()
    	{
    		MyButton = new Button();
    		MyButton.Content = "I'm a button!";
    	}
    
    	#region MyButton
    
    	public Button MyButton
    	{
    		get { return (Button)GetValue(MyButtonProperty); }
    		set { SetValue(MyButtonProperty, value); }
    	}
    
    	public static readonly DependencyProperty MyButtonProperty =
    		DependencyProperty.Register("MyButton", typeof(Button), typeof(Customer));
    
    	#endregion
    	
    }

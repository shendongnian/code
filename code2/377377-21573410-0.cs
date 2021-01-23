    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    public partial class MainWindow : Window
    {
    	private bool MoveFocus_Next(UIElement uiElement)
    	{
    		if (uiElement != null)
    		{
    			uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    			return true;
    		}
    		return false;
    	}
    
    	public MainWindow()
    	{
    		InitializeComponent();
    	}
    
    	private void Window_Loaded(object sender, RoutedEventArgs e)
    	{
    		EventManager.RegisterClassHandler(typeof(Window), Window.PreviewKeyUpEvent, new KeyEventHandler(Window_PreviewKeyUp));
    	}
    
    	private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
    	{
    		if (e.Key == Key.Enter)
    		{
    			IInputElement inputElement = Keyboard.FocusedElement;
    			if (inputElement != null)
    			{
    				System.Windows.Controls.Primitives.TextBoxBase textBoxBase = inputElement as System.Windows.Controls.Primitives.TextBoxBase;
    				if (textBoxBase != null)
    				{
    					if (!textBoxBase.AcceptsReturn)
    						MoveFocus_Next(textBoxBase);
    					return;
    				}
    				if (
    					MoveFocus_Next(inputElement as ComboBox)
    					||
    					MoveFocus_Next(inputElement as Button)
    					||
    					MoveFocus_Next(inputElement as DatePicker)
    					||
    					MoveFocus_Next(inputElement as CheckBox)
    					||
    					MoveFocus_Next(inputElement as DataGrid)
    					||
    					MoveFocus_Next(inputElement as TabItem)
    					||
    					MoveFocus_Next(inputElement as RadioButton)
    					||
    					MoveFocus_Next(inputElement as ListBox)
    					||
    					MoveFocus_Next(inputElement as ListView)
    					||
    					MoveFocus_Next(inputElement as PasswordBox)
    					||
    					MoveFocus_Next(inputElement as Window)
    					||
    					MoveFocus_Next(inputElement as Page)
    					||
    					MoveFocus_Next(inputElement as Frame)
    				)
    					return;
    			}
    		}
    	}
    }

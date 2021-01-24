        public sealed partial class MainPage : Page
        {
        	ContentDialog dialogInput = new ContentDialog();
        	TextBox inputBox = new TextBox();
        
        	public MainPage()
        	{
        		this.InitializeComponent();
        		//you only want to call this once... not each time you show the dialog
        		Setup();
        		Loaded += Page_Loaded;
        	}
        
        	public void Page_Loaded(object sender, RoutedEventArgs e)
        	{
        	   WaitingInput();
        	}
        
        	/// <summary>
        	/// initializes the dialog and its child - the textbox
        	/// </summary>
        	private void Setup()
        	{
        		inputBox.AcceptsReturn = false;
        		inputBox.Height = 32;
        		inputBox.Width = 300;
        		inputBox.TextChanging += TextChangingHandler;
        		dialogInput.Content = inputBox;
        		dialogInput.Title = "Input Reader";
        		dialogInput.IsPrimaryButtonEnabled = false;
        		dialogInput.IsSecondaryButtonEnabled = false;
        		dialogInput.PrimaryButtonText = "";
        	}
        
        	private void ResetDialog()
        	{
        		inputBox.Text = string.Empty;
        		WaitingInput();
        	}
        
        	public async void WaitingInput()
        	{
        		await dialogInput.ShowAsync();
        	}
        
        	private async void TextChangingHandler(TextBox sender, TextBoxTextChangingEventArgs e)
        	{
        		if (sender.Text.Length < 24)
        		{
        			return;
        		}
        
        		dialogInput.Hide();
        		await DoSomething(sender.Text);
        	}
        
        	private async Task DoSomething(string inputTextUSER)
        	{
        		if (inputTextUSER == "123456789012345678901234")
        		{
        			//note: the dialog will not show again.  May as well close the app
        			return;
        		}
        		//show inputted text in textblock
        		inputText.Text = inputTextUSER;
        		await Task.Delay(3000);
        		//after 3 seconds, show the dialog again - unclear requirement
        		ResetDialog();
        	}
    
    } 

    public sealed partial class InputTextDialog : ContentDialog
    {
    	public event EventHandler<EnteredTextArgs> OnValueEntered;
    	public InputTextDialog()
    	{
    		this.InitializeComponent();
    	}
    
    	private void OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
    	{
    		if (sender.Text.Length == 24)
    		{
    			OnValueEntered?.Invoke(this, new EnteredTextArgs() { EnteredText = sender.Text });
    			sender.Text = string.Empty;
    			this.Hide();
    		}
    	}
    }

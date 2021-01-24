    public sealed partial class MainPage : Page
    {
    	InputTextDialog dialog = new InputTextDialog();
    	public MainPage()
    	{
    		this.InitializeComponent();
    		Loaded += MainPage_Loaded;
    	}
    
    	private void MainPage_Loaded(object sender, RoutedEventArgs e)
    	{
    		dialog.OnValueEntered += Dialog_OnValueEntered;
    	}
    
    	private void Dialog_OnValueEntered(object sender, EnteredTextArgs e)
    	{
    		txtblockResult.Text = e.EnteredText;
    	}
    
    	private async void OnShowClick(object sender, RoutedEventArgs e)
    	{
    		await dialog.ShowAsync();
    	}
    }

csharp
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        btn_handle();
    }
    public void Button_Click(object sender, RoutedEventArgs e)
    {
        btn_handle();
    }
    public void btn_handle()
    {
        string t = "Test";
        navigate_page2(t);
    }
    public void navigate_page2(string t)
    {
        this.Frame.Navigate(typeof(Page2), t);
    }
}
Best regards.

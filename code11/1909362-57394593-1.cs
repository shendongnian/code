xml
<UserControl
    ...
    >
    <Grid>
        <Grid HorizontalAlignment="Right" VerticalAlignment="Bottom">
            <Border BorderBrush="{StaticResource ApplicationForegroundThemeBrush}" 
            Background="{StaticResource ApplicationPageBackgroundThemeBrush}"
            BorderThickness="2" Width="500" Height="500">
                <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
                    <WebView x:Name="WebView1" Source="https://www.bing.com/" Width="490" Height="490" HorizontalAlignment="Center"/>
                </StackPanel>
            </Border>
        </Grid>
    </Grid>
</UserControl>
The code-behind:
csharp
public sealed partial class TestPopup : UserControl
{
    private Popup _popup = null;
    public TestPopup()
    {
        this.InitializeComponent();
        // If you need to top placement, please comment out the Width/Height statement below
        this.Width = Window.Current.Bounds.Width;
        this.Height = Window.Current.Bounds.Height;
        //Assign the current control to the Child property of the popup. The Child property is what the popup needs to display.
        _popup = new Popup();
        _popup.Child = this;
    }
    public void ShowPopup()
    {
        _popup.IsOpen = true;
    }
    public void HidePopup()
    {
        _popup.IsOpen = false;
    }
}
**Use C# code references where needed**
csharp
public sealed partial class MainPage : Page
{
    private TestPopup _popup = new TestPopup();
    public MainPage()
    {
        this.InitializeComponent();
        _popup.ShowPopup();
    }
}
To ensure that it is in the lower right corner at any width, you can listen to the page's `SizeChanged` event.
csharp
private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
{
    _popup.Width = Window.Current.Bounds.Width;
    _popup.Height = Window.Current.Bounds.Height;
    // If you need to use the Width/Height of the page
    // _popup.Width = e.NewSize.Width;
    // _popup.Height = e.NewSize.Height;
}
Best regards.

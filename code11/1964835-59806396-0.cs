csharp
private bool _isInit = false;
public MyPage()
{
    this.InitializeComponent();
    NavigationCacheMode = NavigationCacheMode.Enabled;
}
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if (e.NavigationMode == NavigationMode.Back || _isInit)
        return;
    // Do Somethings...
    
    _isInit = true;
}
When the page is cached, it maintains the current state of the page, which means two things:
1. The `ContentDialog` you create will not be replaced by the `ContentDialog` of the newly created page, resulting in an error.
2. When leaving and returning from the page, the page will not be repeatedly created.
Best regards.

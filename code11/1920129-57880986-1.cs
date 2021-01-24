csharp
public ReusablePage()
{
    InitializeComponent();
    NavigationCacheMode = NavigationCacheMode.Enabled;
}
At the same time, you can also use `e.NavigationMode` to determine the way to navigate to the page.
csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if(e.NavigationMode == NavigationMode.Back)
    {
        // Do something.
    }
    base.OnNavigatedTo(e);
}
Your error occurred when rendering the visual tree. There is no more detailed explanation of the error, but the cache page can effectively solve this problem.
Best regards.

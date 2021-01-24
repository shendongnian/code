csharp
public OtherPage()
{
    this.InitializeComponent();
    NavigationCacheMode = NavigationCacheMode.Enabled;
}
By caching the current page, the page will not be recreated on the next navigate, which means that no new memory is added.
Best regards.

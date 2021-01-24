csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if(e.Parameter != null && e.Parameter is UIElement)
    {
        Content = (UIElement) e.Parameter;
    }
    base.OnNavigatedTo(e);
}
The reason for the error is that when you click the back button, you return to the previous page, it calls the `OnNavigatedTo` method, but no arguments are passed, which raises an exception because you can't set the `Page.Content` to null.
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
Best regards.

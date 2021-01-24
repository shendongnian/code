csharp
servicesButton.TouchUpInside += (sender, e) =>
{
    var servicesViewController = TabBarController.ViewControllers.FirstOrDefault(x => x.View.Tag == 5);
    if(servicesViewController != null)
    {
        TabBarController.SelectedViewController = servicesViewController;
    }
};
You can set the tag either in the storyboard/xib or programmatically.

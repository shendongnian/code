csharp
protected override async Task OnInitializeAsync(IActivatedEventArgs args)
{
    await base.OnInitializeAsync(args);
    //We are remapping the default ViewNamePage and ViewNamePageViewModel naming to ViewNamePage and ViewNameViewModel to
    //gain better code reuse with other frameworks and pages within Windows Template Studio
    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
    {
        var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "App1.ViewModels.{0}ViewModel, App1", viewType.Name.Substring(0, viewType.Name.Length - 4));
        return Type.GetType(viewModelTypeName);
    });
}
Please note this function, which is used to register the ViewModel of the current page. According to the corresponding naming convention, if the name of Page is `{name}Page.xaml`, then ViewModel is `{name}ViewModel.cs`.
---
**Update**
> How can I initialize the ShellPage on navigated?
To be frank, such behavior does not fit the current architecture. Because by default, the application has only one rootFrame, but since you remove the override of the CreateShell method, it is bound to introduce a second frame, which will cause an unknown error.
If you insist, I provide a method here, but it will not save the `session state` correctly when the software is closed.
**App.xaml.cs**
csharp
public static App Instance;
public App()
{
    InitializeComponent();
    Instance = this;
}
**SignInPage.xaml.cs**
Please listen for the `SignInButton_Click` event in xaml
csharp
private void SignInButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
    var rootFrame = Window.Current.Content as Frame;
    var frame = new Frame();
    App.Instance.SetNavigationFrame(frame);
    rootFrame.Navigate(typeof(ShellPage), frame);
}
**ShellPage.xaml.cs**
csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if(e.Parameter is Frame frame)
    {
        SetRootFrame(frame);
        frame.Navigate(typeof(MainPage));
    }
}
Best regards.

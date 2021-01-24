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
Best regards.

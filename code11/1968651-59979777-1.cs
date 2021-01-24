c#
public class ViewModelBaseDependencies{
    public ViewModelBaseDependencies(INavigationService navigationService, IDialogService dialogService){
    //...
}
public ViewModelBase(ViewModelBaseDependencies dependencies)
{
    NavigationService = dependencies.NavigationService;
    DialogService = dependencies.DialogService;
}
public MainPageViewModel(ViewModelBaseDependencies dependencies)
        : base(dependencies)
Then you only need to pass the one constructor argument and can trivially add new dependencies.

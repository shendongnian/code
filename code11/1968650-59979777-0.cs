c#
public class ViewModelBaseDependencies{
    public ViewModelBaseDependencies(INavigationService navigationService, IDialogService dialogService){
    //...
}
Then you only need to pass the one constructor argument and can trivially add new dependencies.

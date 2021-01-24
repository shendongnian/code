cs
public void ShowChildView()
{
    ShowActivityIndicator = true;
    var childViewModel = new ChildViewModel(HostScreen);
    // Use the extension method to get an observable when the child view is navigated away from, subscribe and set the variable.
    childViewModel.WhenNavigatingFromObservable().Subscribe(x => ShowActivityIndicator = false);
    appBootstrapper.Router.Navigate.Execute(childViewModel).Subscribe();
} 
Second option, if you don't mind the functionality happening on the child, you could use the WhenActivated() mechanic
cs
public ChildView()
{
    this.WhenActivated(disposable => 
     {
        // do activation logic.
        return new[] { Disposable.Create(() => DoDeactivationLogic());
     }
Further details here https://reactiveui.net/docs/handbook/when-activated/

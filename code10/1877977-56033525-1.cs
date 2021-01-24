cs
public class TestViewModel : ReactiveObject, ISupportsActivation
{
    private readonly ObservableAsPropertyHelper<bool> _status;
    public bool Status => _status.Value;
    public ViewModelActivator Activator { get; } = new ViewModelActivator();
    public TestViewModel(ILongLivedObject obj)
    {
         _status = obj.Status.ToProperty(this, vm => vm.Status);
         this.WhenActivated(disposables =>
         {
             disposables(_status);
         }
    }
}
The `disposables` parameter passed into the `WhenActivated` lambda is a Func that takes a `IDisposable`
In the view, make sure you derive off `IActivatable` (soon to be renamed `IActivatableView`) and use WhenActivated in the constructor of the view as well.

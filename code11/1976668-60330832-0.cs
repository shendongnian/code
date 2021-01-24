class Manager : IObservable<ManagerState>
{
    private Boolean isEnabled; // backing field
    public Boolean IsEnabled
    {
        get { return this.isEnabled; }
        set
        {
            this.isEnabled = value;
            this.NotifySubscribers();
        }
    }
    private Boolean isActive; // backing field
    public Boolean IsActive
    {
        get { return this.isActive; }
        set
        {
            this.isActive = value;
            this.NotifySubscribers();
        }
    }
    #region Observers (Subscribers) handling:
    private readonly ConcurrentBag<IObserver<ManagerState>> subscribers = new ConcurrentBag<IObserver<ManagerState>>();
    
    private void NotifySubscribers()
    {
        ManagerState snapshot = new ManagerState(
            this.IsEnabled,
            this.IsActive,
            // etc
        );
        foreach( IObserver<ManagerState> observer in this.subscribers )
        {
            observer.OnNext( snapshot );
        } 
    }
    
    #endregion
}
// Represents a snapshot of the state of a `Manager`
class ManagerState
{
    public ManagerState( Boolean isEnabled, Boolean isActive )
    {
        this.IsEnabled = isEnabled;
        this.IsActive  = isActive;
    }
    public Boolean IsEnabled { get; }
    public Boolean IsActive  { get; }
    // any other members, etc
}
Note that this *can* be combined with support for `INotifyPropertyChanged` like so (though I think this is a bad idea because supporting multiple ways to accomplish the same thing will end-up confusing your users/consumers/coworkers) - kinda like how `System.Net.Sockets.Socket` has `Accept`, `AcceptAsync`, `BeginAccept`/`EndAccept` because it supports synchronous, and the APM and EAP asynchronous paradigms (but not TPL for some reason).
class Manager : IObservable<ManagerState>, INotifyPropertyChanged
{
    private Boolean isEnabled; // backing field
    public Boolean IsEnabled
    {
        get { return this.isEnabled; }
        set
        {
            this.isEnabled = value;
            this.OnPropertyChanged( nameof(this.IsEnabled) );
        }
    }
    private Boolean isActive; // backing field
    public Boolean IsActive
    {
        get { return this.isActive; }
        set
        {
            this.isActive = value;
            this.OnPropertyChanged( nameof(this.IsActive) );
        }
    }
    #region INotifyPropetyChanged and Observers (Subscribers) handling:
    private readonly ConcurrentBag<IObserver<ManagerState>> subscribers = new ConcurrentBag<IObserver<ManagerState>>();
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected void OnPropertyChanged( String name )
    {
        // First, notify users of INotifyPropetyChanged:
        this.PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( name ) );
        // Then notify users of IObservable:
        ManagerState snapshot = new ManagerState(
            this.IsEnabled,
            this.IsActive,
            // etc
        );
        foreach( IObserver<ManagerState> observer in this.subscribers )
        {
            observer.OnNext( snapshot );
        } 
    }
    
    #endregion
}

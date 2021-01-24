public class ViewModel : INotifyPropertyChanged
{
    bool _isServerStarted;
    public ViewModel()
    {
        StartServer = new DelegateCommand(OnStartServerExecute, OnStartServerCanExecute);
        StopServer = new DelegateCommand(OnStopServerExecute, OnStopServerCanExecute);
    }
    void OnStartServerExecute()
    {
        IsServerStarted = true;
    }
    bool OnStartServerCanExecute()
    {
        return !IsServerStarted;
    }
    void OnStopServerExecute()
    {
        IsServerStarted = false;
    }
    bool OnStopServerCanExecute()
    {
        return IsServerStarted;
    }
    void RaiseCanExecuteChanged()
    {
        StartServer.RaiseCanExecuteChanged();
        StopServer.RaiseCanExecuteChanged();
    }
    public bool IsServerStarted 
    {
        get => _isServerStarted;
        set
        {
            _isServerStarted = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsServerStarted)));
            RaiseCanExecuteChanged();
        }
    }
    public DelegateCommand StartServer { get; }
    public DelegateCommand StopServer { get; }
    public event PropertyChangedEventHandler PropertyChanged;
}
You just should use CommandManager.InvalidateRequerySuggested() for updating button state.

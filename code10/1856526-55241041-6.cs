    public class InteropBase : INotifyPropertyChanged
    {
    	protected IntPtr _ptr;
    	protected readonly AssetCallback _onAssetErrorMessageChanged;
    
    	public delegate void AssetCallback(IntPtr strPtr);
    
    	public List<string> LogMessages { get; private set; } = new List<string>();
    
    	public InteropBase()
    	{
    		_onAssetErrorMessageChanged = LogUpdater;
    	}
    
    	private unsafe void LogUpdater(IntPtr strPtr)
    	{
    		var LastLogMessage = new string((char*)strPtr);
    		LogMessages.Add(LastLogMessage);
    		OnPropertyChanged(nameof(LogMessages));
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	[NotifyPropertyChangedInvocator]
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    }

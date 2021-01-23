    public class ViewModelBase : INotifyPropertyChanged
    {
    	protected delegate void OnUiThreadDelegate();
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void SendPropertyChanged(string propertyName)
    	{
    		if (this.PropertyChanged != null)
    		{
    			// Ensure property change is on the UI thread
    			this.OnUiThread(() => this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
    		}
    	}
    
    	protected void OnUiThread(OnUiThreadDelegate onUiThreadDelegate)
    	{
    		// Are we on the Dispatcher thread ?
    		if (Deployment.Current.Dispatcher.CheckAccess())
    		{
    			onUiThreadDelegate();
    		}
    		else
    		{
    			// We are not on the UI Dispatcher thread so invoke the call on it.
    			Deployment.Current.Dispatcher.BeginInvoke(onUiThreadDelegate);
    		}
    	}
    }

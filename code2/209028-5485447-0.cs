    public static readonly DependencyProperty progressProperty = DependencyProperty.Register("progress", typeof(int), typeof(this));
    public int progress
    	{
    		get
    		{
    			return (int)this.Dispatcher.Invoke(
    				   System.Windows.Threading.DispatcherPriority.Background,
    				   (DispatcherOperationCallback)delegate { return GetValue(progressProperty ); },
    				   progressProperty );
    		}
    		protected set
    		{
    			this.Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { SetValue(progressProperty , value); }, value);
    		}
    	}

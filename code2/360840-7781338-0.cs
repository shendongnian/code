    public class Slot : INotifyPropertyChanged
    	{
    		private bool _hasPlayed;
    
    		private bool HasPlayed
    		{
    			get { return _hasPlayed; }
    			set
    			{
    				_hasPlayed = value;
    				InvokePropertyChanged(new PropertyChangedEventArgs("HasPlayed"));
    			}
    		}
    
    		#region INotifyPropertyChanged Members
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		#endregion
    
    		public void InvokePropertyChanged(PropertyChangedEventArgs e)
    		{
    			PropertyChangedEventHandler handler = PropertyChanged;
    			if (handler != null)
    			{
    				handler(this, e);
    			}
    		}
    	}

    public class MyParent : INotifyPropertyChanged
    {
    	
    	private ObservableCollection<MyChild> _MyChildren;
    	private ContinuousValue<MyChild> _ContinuousIsChanged = null;
    
    	public MyParent()
    	{
    		_MyChildren = new ObservableCollection<MyChild>();
    		
    		// Creat the ContinuousFirstOrDefault to watch the MyChildren collection.
    		// This will monitor for newly added instances, 
    		// as well as changes to the "IsChanged" property on 
    		// instances already in the collection.
    		_ContinuousIsChanged = MyChildren.ContinuousFirstOrDefault(child => child.IsChanged);
    		_ContinuousIsChanged.PropertyChanged += (s, e) => RaiseChanged("IsChanged");
    	}
    
        public ObservableCollection<MyChild> MyChildren
    	{
    		get { return _MyChildren; }
    	}
    
        public bool IsChanged
        {
            get
            {
    			// If there is at least one child that matches the 
    			// above expression, then something has changed.
    			if (_ContinuousIsChanged.Value != null)
    				return true;
    			
    			return false;
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
    
    public class MyChild : INotifyPropertyChanged
    {
        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value == value)
                    return;
                _Value = value;
                RaiseChanged("Value");
                RaiseChanged("IsChanged");
            }
        }
        private int _DefaultValue;
        public int DefaultValue
        {
            get
            {
                return _DefaultValue;
            }
            set
            {
                if (_DefaultValue == value)
                    return;
                _DefaultValue = value;
                RaiseChanged("DefaultValue");
                RaiseChanged("IsChanged");
            }
        }
    
        public bool IsChanged
        {
            get
            {
                return (Value != DefaultValue);
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

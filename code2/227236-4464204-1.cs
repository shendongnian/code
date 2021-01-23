    public class PropertyChangeMonitor
    {
        //=======================================================================================================
        //	Constructors
        //=======================================================================================================
        #region PropertyChangeMonitor()
        public PropertyChangeMonitor()
        {
                
        }
        #endregion
    
        //=======================================================================================================
        //	Protected Properties
        //=======================================================================================================
        #region Sources
        protected ConcurrentDictionary<INotifyPropertyChanged, Action<string>> Sources
        {
            get
            {
                return _sources;
            }
        }
        private ConcurrentDictionary<INotifyPropertyChanged, Action<string>> _sources = new ConcurrentDictionary<INotifyPropertyChanged,Action<string>>();
        #endregion
    
        //=======================================================================================================
        //	Public Methods
        //=======================================================================================================
        #region Register(INotifyPropertyChanged source, Action<string> target)
        public void Register(INotifyPropertyChanged source, Action<string> target)
        {
            if(source == null || target == null)
            {
                return;
            }
    
            if(!this.Sources.ContainsKey(source))
            {
                if (this.Sources.TryAdd(source, target))
                {
                    source.PropertyChanged += (o, e) =>
                    {
                        target.Invoke(e.PropertyName);
                    };
                }
            }
        }
        #endregion
    
        #region Unregister(INotifyPropertyChanged source, Action<string> target)
        public void Unregister(INotifyPropertyChanged source, Action<string> target)
        {
            if (source == null || target == null)
            {
                return;
            }
    
            if (this.Sources.ContainsKey(source))
            {
                if (this.Sources.TryRemove(source, out target))
                {
                    source.PropertyChanged -= (o, e) =>
                    {
                        target.Invoke(e.PropertyName);
                    };
                }
            }
        }
        #endregion
    }

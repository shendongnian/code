    public class Person : INotifyPropertyChanged
    {
        //=======================================================================================================
        //	Constructors
        //=======================================================================================================
        #region Person()
        public Person()
        {
            this.ChangeMonitor.Register(this.Name, OnPropertyChanged);
        }
        #endregion
    
        //=======================================================================================================
        //	Protected Properties
        //=======================================================================================================
        #region ChangeMonitor
        protected PropertyChangeMonitor ChangeMonitor
        {
            get
            {
                return _monitor;
            }
        }
        private PropertyChangeMonitor _monitor = new PropertyChangeMonitor();
        #endregion
    
        //=======================================================================================================
        //	Public Properties
        //=======================================================================================================
        #region Name
        public FullName Name
        {
            get
            {
                return _personName;
            }
    
            set
            {
                if (!FullName.Equals(_personName, value))
                {
                    _personName = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        private FullName _personName = new FullName();
        #endregion
    
        //=======================================================================================================
        //	INotifyPropertyChanged Implementation
        //=======================================================================================================
        #region PropertyChanged
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <remarks>
        /// The <see cref="PropertyChanged"/> event can indicate all properties on the object have changed 
        /// by using either a <b>null</b> reference (Nothing in Visual Basic) or <see cref="String.Empty"/> 
        /// as the property name in the <see cref="PropertyChangedEventArgs"/>.
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    
        #region OnPropertyChanged(string propertyName)
        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    
        #region OnPropertyChanged(PropertyChangedEventArgs e)
        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="PropertyChangedEventArgs"/> that contains the event data.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
    
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }

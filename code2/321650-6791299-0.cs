    public class StaffIncentiveHelperObject : INotifyPropertyChanged//
        {
            public delegate void CollectionChangedDelegate();
            public static CollectionChangedDelegate CollectionChanged;
    
            public StaffIncentiveHelperObject(staffincentive input)
            {
                this._StaffIncentive = input;
            }
    
    
            private staffincentive _StaffIncentive;
            public staffincentive StaffIncentive
            {
                get { return _StaffIncentive; }
                set
                {
                    if (_StaffIncentive == value) return;
                    _StaffIncentive = value;
                    OnPropertyChanged("StaffIncentive");
                }
            }
    
            public decimal? StaffIncentiveIncrement
            {
                get 
                { 
                    return _StaffIncentive.increment; 
                }
                set
                {
                    if (_StaffIncentive.increment != value)
                    {
                        _StaffIncentive.increment = value;
                        OnPropertyChanged("StaffIncentive");
                    }
                }
            }
    
            public string StaffIncentiveName
            {
                get
                {
                    return _StaffIncentive.name;
                }
                set
                {
                    if (_StaffIncentive.name != value)
                    {
                        _StaffIncentive.name = value;
                        OnPropertyChanged("StaffIncentive");
                    }
                }
            }
    
            public byte? StaffIncentiveType
            {
                get
                {
                    return _StaffIncentive.type;
                }
                set
                {
                    if(_StaffIncentive.type != value)
                    {
                        _StaffIncentive.type = value;
                        OnPropertyChanged("StaffIncentive");
                    }
                }
            }
    
            private ObservableCollection<StaffIncentiveLineHelperObject> _StaffIncentiveLines = new ObservableCollection<StaffIncentiveLineHelperObject>();
            public ObservableCollection<StaffIncentiveLineHelperObject> StaffIncentiveLines
            {
                get { return _StaffIncentiveLines; }
                set { _StaffIncentiveLines = value; OnPropertyChanged("StaffIncentiveLines"); }
            }
    
    
            public void AddStaffIncentiveLine( staffincentiveline SIL)
            {
                SIL.staffincentive = this._StaffIncentive;
                _StaffIncentive.staffincentiveline.Add(SIL);
                StaffIncentiveLines.Add(new StaffIncentiveLineHelperObject(SIL, this));
                //OnPropertyChanged("StaffIncentiveLine");
                if (CollectionChanged != null)
                {
                    CollectionChanged.Invoke();
                }
    
            }
    
            public void RemoveStaffIncentiveLine(StaffIncentiveLineHelperObject SILHO)
            {
                _StaffIncentive.staffincentiveline.Remove(SILHO.StaffIncentiveLine);
                _StaffIncentiveLines.Remove(SILHO);
                //OnPropertyChanged("StaffIncentiveLine");
                if (CollectionChanged != null)
                {
                    CollectionChanged.Invoke();
                }
    
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string name)
            {
                var x = PropertyChanged;
                if (x != null)
                    x(this, new PropertyChangedEventArgs(name));
            }
    
            #endregion
        }
    
        public class StaffIncentiveLineHelperObject : INotifyPropertyChanged//, INotifyCo
        {
            public StaffIncentiveLineHelperObject(staffincentiveline input, StaffIncentiveHelperObject parent)
            {
                this._StaffIncentiveLine = input;
                this.Parent = parent;
            }
    
    
            public StaffIncentiveHelperObject Parent { get; set;}
    
            private staffincentiveline _StaffIncentiveLine;
            public staffincentiveline StaffIncentiveLine
            {
                get { return _StaffIncentiveLine; }
                set
                {
                    if (_StaffIncentiveLine == value) return;
                    _StaffIncentiveLine = value;
                    OnPropertyChanged("StaffIncentiveLine");
                }
            }
    
            public decimal? StaffIncentiveLineLbound
            {
                get
                {
                    return _StaffIncentiveLine.lbound;
                }
                set
                {
                    if (_StaffIncentiveLine.lbound != value)
                    {
                        _StaffIncentiveLine.lbound = value;
                        OnPropertyChanged("StaffIncentiveLine");
                    }
                }
            }
    
            public double? StaffIncentiveLinePercentage
            {
                get
                {
                    return _StaffIncentiveLine.percentage;
                }
                set
                {
                    if (_StaffIncentiveLine.percentage != value)
                    {
                        _StaffIncentiveLine.percentage = value;
                        OnPropertyChanged("StaffIncentiveLine");
                    }
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string name)
            {
                var x = PropertyChanged;
                if (x != null)
                    x(this, new PropertyChangedEventArgs(name));
    
            }
    
            #endregion
        }

        public static Visibility LabelShown
        {
            get { return _labelShown; }
            set
            {
                _labelShown = value;
                if ( StaticEvent != null )
                {
                    StaticEvent();
                }
            }
        }
        private static event Action StaticEvent;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { StaticEvent += () => value(this, new PropertyChangedEventArgs("LabelShown")); }
            remove { StaticEvent -= () => value(this, new PropertyChangedEventArgs("LabelShown")); }
        }

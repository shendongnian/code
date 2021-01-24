        public ApplicationUserControl OldValue
        {
            get => mOldValue;
            set 
            { 
                mOldValue = value; 
                //do stuff when your reference is changed...
            }
        }
        private ApplicationUserControl mOldValue;
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            OldValue = (ApplicationUserControl)value;
            switch (OldValue)
            {
                case ApplicationUserControl.Login:
                    return new myUC();
            }
        }

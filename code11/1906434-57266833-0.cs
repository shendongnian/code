        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                // *** The 'parameter' argument contains the parameter. Convert to relevant type and call the required logic. ***
                ApplicationUserControl oldControl = (ApplicationUserControl)parameter;
                // Perform required logic...
    
                // Find the appropriate page
                switch ((ApplicationUserControl)value)
                {
                    case ApplicationUserControl.Login:
                        return new myUC();
                }
            }

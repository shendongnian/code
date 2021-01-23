    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) 
        { 
            var previousMessage = values[0] as MessageItem; 
            var currentMessage = values[1] as MessageItem; 
            if ((previousMessage != null) && (currentMessage != null)) 
            { 
                return previousMessage.UserName.Equals(currentMessage.UserName) ? Visibility.Hidden : Visibility.Visible; 
            }           
     
            return Visibility.Visible; 
        } 

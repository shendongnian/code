    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) 
        { 
            var collection = values[0] as IEnumerable<MessageItem>; 
            var item = values[1] as MessageItem; 
            if ((collection != null) && (item != null) && (collection.Count() > 0)) 
            { 
                return collection.Last().UserName == item.UserName ? Visibility.Hidden : Visibility.Visible; 
            }           
     
            return Visibility.Hidden; 
        } 

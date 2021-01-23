    public class GroupsConverter : IValueConverter
    {
        public object Convert(object value, ...)
        {
            return ((CollectionViewSource)value).View.Groups;
        }
       
        ....
    }
 

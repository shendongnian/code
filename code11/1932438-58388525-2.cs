    [ValueConversion(typeof(List<WorksheetColumn>), typeof(List<WorksheetColumn>))]
    public class ListFilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<WorksheetColumn> worksheets = value as List<WorksheetColumn>;
            int keepColumn = (int)parameter;
            
            return worksheets.Where(header => header.ID == 0 || header.Selected == false || header.ID == keepColumn).ToList();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

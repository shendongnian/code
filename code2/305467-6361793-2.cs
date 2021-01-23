    public class TitleAuthorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Book)) throw new NotSupportedException();
            Book b = value as Book;
            return b.Title + " - " + b.Author;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

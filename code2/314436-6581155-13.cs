    public class GroupByType : IValueConverter
    {
        public string type { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (type == "root")
            {
                if (value is Product)
                {
                    return "Product";
                }
                return null;
            }
            if (type == "subs")
            {
                if (value is Book)
                {
                    return "Book";
                }
                if (value is Disk)
                {
                    return "Disk";
                }
            }
            if (type == "main")
            {
                if (value is ProgrammingBook)
                {
                    return "PBook";
                }
                if (value is RecipeBook)
                {
                    return "RBook";
                }
                if (value is Disk)
                {
                    return "Disk";
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

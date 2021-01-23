    public class IndexedValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (values.Length < 2) return null;
            var index = Convert.ToInt32(values[1], culture);
            var array = values[0] as Array;
            if (array != null) return array.GetValue(index);
            var list = values[0] as IList;
            if (list != null) return list[index];
            var enumerable = values[0] as IEnumerable;
            if (enumerable != null)
            {
                int ii = 0;
                foreach (var item in enumerable)
                {
                    if (ii++ == index) return item;
                }
            }
            return null;
        }
    // ... Implement ConvertBack as desired

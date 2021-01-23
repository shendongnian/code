    public class FactorAndMillimeterToPixelConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Member
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((values.Length < 2)
                || !(values[0] is double?))
                return Binding.DoNothing;
            double? factor = (double?)values[0];
            switch(values.Length)
            {
                case 2:
                    if(!(values[1] is double))
                        return Binding.DoNothing;
                    // values[0]: Factor, values[1]: SizeMM
                    // if Factor is null, no fallback provided -> donothing
                    if (!factor.HasValue)
                        return Binding.DoNothing;
                    // else return calculated width
                    return factor.Value * (double)values[1];
                case 3:
                    if (!(values[1] is double) || !(values[2] is double))
                        return Binding.DoNothing;
                    // values[0]: Factor, values[1]: SizeMM, values[2]: SizePixelsFallback
                    // if Factor is null, but fallback provided -> return fallback
                    if (!factor.HasValue)
                        return (double)values[2];
                    // else return calculated width
                    return factor.Value * (double)values[1];
                default:
                    // value.Length > 3
                    return Binding.DoNothing;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

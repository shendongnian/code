    public GradeToBrushConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Grade grade)
            {
                switch (grade)
                {
                    case Grade.pass:
                        return Brushes.Green;
                    case fail:
                        return Brushes.Red;
                    default:
                        return Brushes.Black; // Or a more sensible default.
                }
            }
            return Brushes.Black;
        }
        // I haven't provided the ConvertBack but you should be able to work this bit out.
    }

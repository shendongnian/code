    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage image = new BitmapImage(); 
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(value.ToString()); 
            image.EndInit();  
            return image;
        }
    <Image Source="{Binding Path, Converter={StaticResource ImageConverter}}"/>

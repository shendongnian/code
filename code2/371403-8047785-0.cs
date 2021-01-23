           <Image x:Name="UserImage" Source="{Binding MembershipUserViewModel.UserId, Converter={StaticResource _userIdToImageConverter}, UpdateSourceTrigger=Explicit}" Stretch="Fill" />
    public class UserIdToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var image = String.Format("{0}/../{1}.jpg",
					  Application.Current.Host.Source,
					  value);
            var bitmapImage = new BitmapImage(new Uri(image)){CreateOptions = BitmapCreateOptions.IgnoreImageCache};
            return bitmapImage;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

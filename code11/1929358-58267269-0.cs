    public class IdToIconConverter : BaseValueConverter<IdToIconConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ControlTemplate controlTemplate = new ControlTemplate();
            switch ((int)value)
            {
                case 1:
                    controlTemplate = (ControlTemplate)Application.Current.Resources["WelcomeIcon"];
                    return controlTemplate;
                default:
                    //Debugger.Break();
                    return null;
            }
        }
	}

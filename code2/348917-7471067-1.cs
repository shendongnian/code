     public class SplitTemplateSelector : DependencyObject, IValueConverter
        {
            public static readonly DependencyProperty SingleSplitTemplateProperty =
                DependencyProperty.Register("SingleSplitTemplate",
                                            typeof (DataTemplate),
                                            typeof(SplitTemplateSelector),
                                            null);
    
            public DataTemplate SingleSplitTemplate
            {
                get { return (DataTemplate) GetValue(SingleSplitTemplateProperty); }
                set { SetValue(SingleSplitTemplateProperty, value); }
            }
    
            public static readonly DependencyProperty MultiSplitTemplateProperty =
                DependencyProperty.Register("MultiSplitTemplate",
                                            typeof (DataTemplate),
                                            typeof(SplitTemplateSelector),
                                            null);
    
            public DataTemplate MultiSplitTemplate
            {
                get { return (DataTemplate) GetValue(MultiSplitTemplateProperty); }
                set { SetValue(MultiSplitTemplateProperty, value); }
            }
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                int splitCount = (int)value;
                return splitCount == 1 ? SingleSplitTemplate : MultiSplitTemplate;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
    
        }

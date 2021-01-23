    public class NameCellTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            
            // find the data template with a specific x:Key
            return element.FindResource("someNameTemplate") as DataTemplate;
        }
    }
    public class StatusCellTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            
            // find the data template with a specific x:Key
            return element.FindResource("someStatusCellTemplate") as DataTemplate;
        }
    }

    public class TestTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(
                                           object item, 
                                           DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element == null || item == null)
                return null;
            if (item.GetType().Name.Contains("TestClass"))
                return element.FindResource("TestClassTemplate") as DataTemplate;
            // Check for other classes here...
            return null;
        }
    }

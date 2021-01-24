    public class ContentControlDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is Task)
            {
                if (// your condition)
                    return
                        element.FindResource("BalanceAmountControls") as  DataTemplate;
                else
                    return
                        element.FindResource("NonBalanceAmountControls") as DataTemplate;
            }
            return null;
        }
    }

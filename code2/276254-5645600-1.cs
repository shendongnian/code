        public class ProjectViewModelTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is ViewModel.ProjectViewModel)
            {
                if ((item as ViewModel.ProjectViewModel).EditMode)
                {
                    return element.FindResource("ProjectEditViewTemplate") as DataTemplate;
                }
                else
                {
                    return element.FindResource("ServiceSelectionViewTemplate") as DataTemplate;
                }
            }
            else
                return base.SelectTemplate(item, container);
        }
        
    }
}

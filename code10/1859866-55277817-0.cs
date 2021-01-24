    public class TreeviewItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return null;
            }
            var wrappedDataTemplate = WrapDataTemplate(((FrameworkElement)container).FindResource("TreeviewItemTemplate") as DataTemplate);
            return wrappedDataTemplate;
        }
        private static DataTemplate WrapDataTemplate(DataTemplate declaredDataTemplate)
        {
            var frameworkElementFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            frameworkElementFactory.SetValue(ContentPresenter.ContentTemplateProperty, declaredDataTemplate);
            var dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = frameworkElementFactory;
            return dataTemplate;
        }
    }

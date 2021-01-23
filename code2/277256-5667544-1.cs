    //namespace MyProject.ViewUtilities
    public class MyDataTemplateSelector: DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var localFrameworkElement = container as FrameworkElement;
            var modelObject = item as ModelObject;
            if(modelObject.BoolProperty){
                return Template(localFrameworkElement, "WhenTrueDataTemplate");
            }
            else
            {
                return Template(localFrameworkElement, "WhenFalseDataTemplate");
            }
        }
        private DataTemplate Template(FrameworkElement localFrameworkElement, string resourceKeyString)
        {
            return localFrameworkElement.FindResource(resourceKeyString) as DataTemplate;
        }
    }

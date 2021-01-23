    public class Selector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string templateKey;
            if (item is CollectionViewGroup)
            {
                if ((item as CollectionViewGroup).Name == null)
                {
                    return null;
                }
                templateKey = "GroupTemplate";
            }
            else if (item is ProgrammingBook)
            {
                templateKey = "pTemplate";
            }
            else if (item is RecipeBook)
            {
                templateKey = "rTemplate";
            }
            else if (item is Disk)
            {
                templateKey = "dTemplate";
            }
            else
            {
                return null;
            }
            return (DataTemplate)((FrameworkElement)container).FindResource(templateKey);
        }
    }

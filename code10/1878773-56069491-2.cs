    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is MyItem myItem)
            {
                switch (myItem.MyValue)
                {
                    case 1:
                        return element.FindResource("TextBoxResource") as DataTemplate;
                    case 2:
                        return element.FindResource("CheckBoxResource") as DataTemplate;
                    case 3:
                        return element.FindResource("ComboBoxResource") as DataTemplate;
                }
            }
            return null; // or provide a default template
        }
    }

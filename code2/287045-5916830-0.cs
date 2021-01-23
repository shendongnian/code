    public class ColumnTemplateSelector : ContentControl
    {
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            switch (newContent.GetType().Name)
            {
                case "Boolean":
                    ContentTemplate = Application.Current.Resources["BooleanDataTemplate"] as DataTemplate;
                    break;
                case "String":
                default:
                    ContentTemplate = Application.Current.Resources["StringDataTemplate"] as DataTemplate;
                    break;
            }
        }
    }

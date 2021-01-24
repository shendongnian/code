    public class TabControlItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TabControlNewItemDataTemplate { get; set; }
        public DataTemplate PlayerTabItemTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var obj = item as CcPlayerViewModel;
            if (obj != null)
            {
                if(obj.Login.IsRunningSession)
                {
                    return PlayerTabItemTemplate;
                }
            }
            return TabControlNewItemDataTemplate ;
        }
    }

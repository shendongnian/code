    public class TabControlContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LoginContentDataTemplate { get; set; }
        public DataTemplate PlayerContentDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var obj = item as CcPlayerViewModel;
            if (obj != null)
            {
                if(obj.Login.IsRunningSession)
                {
                    return PlayerContentDataTemplate;
                }
            }
            return LoginContentDataTemplate;
        }
    }

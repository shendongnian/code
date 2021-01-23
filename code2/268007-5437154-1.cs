    public class QueryObjectDateTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ColumnTemplate { get; set; }
        public DataTemplate ControllerTemplate { get; set; }
        public DataTemplate ValueTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var visualQueryData = item as VisualQueryObject;
            if (visualQueryData == null)
                return null;
            if (visualQueryData.LabelType == "column")
                return ColumnTemplate;
            else if (visualQueryData.LabelType == "controller")
                return ControllerTemplate;
            else if (visualQueryData.LabelType == "value")
                return ValueTemplate;
            else return null;
        }
    }

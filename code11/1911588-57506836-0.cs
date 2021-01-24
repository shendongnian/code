    public class MyCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SolutionTextBlockTemplate { get; set; }
        public DataTemplate SolutionComboboxTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var diff = item as YourDatGridRowObjectType;
            if(diff != null)
            {
                if (<your condition on when to choose this template>))
                    return SolutionTextBlockTemplate;
                return SolutionComboboxTemplate;
            }
            return null;
        }        
    }

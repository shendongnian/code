    public class CustomTemplateSelector : DataTemplateSelector
    {        
        public DataTemplate EvenTemplate { get; set; }        
        public DataTemplate OddTemplate { get; set; }
        public CollectionViewSource Collection { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var list = Collection.Source as IList;
            if (list != null)
            {
                if (list.IndexOf(item) % 2 == 0)
                {
                    return EvenTemplate;
                }
                else
                {
                    return OddTemplate;
                }
            }
            return EvenTemplate;
        }
    }

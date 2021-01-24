        class PanesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MyDocViewATemplate { get; set; }
        public DataTemplate MyDocViewBTemplate { get; set; }
      
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MyDocAViewModel)
                return MyDocViewATemplate;
            if (item is MyDocBViewModel)
                return MyDocViewBTemplate;
        }
    }

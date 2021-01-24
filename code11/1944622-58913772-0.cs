    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate QuestionOpenTemplate { get; set; }
        public DataTemplate QuestionRadioTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is QuestionOpenViewModel)
                return QuestionOpenTemplate;
            if (item is QuestionRadioViewModel)
                return QuestionRadioTemplate;
            return base.SelectTemplate(item, container);
        }
    }

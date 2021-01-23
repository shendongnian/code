    public abstract class QuestionType
    {
        public string Question { get; set; }
    }
    public class TextBoxQuestion : QuestionType
    {
        public string Answer { get; set; }
    }
    public class CheckBoxQuestion : QuestionType
    {
        public bool Answer { get; set; }
    }
    public class ComboBoxQuestion : QuestionType
    {
        public List<string> Values { get; set; }
        public string Answer { get; set; }
    }
    public class QuestionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Combo { get; set; }
        public DataTemplate Text { get; set; }
        public DataTemplate Check { get; set; }
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is TextBoxQuestion) return Text;
            if (item is ComboBoxQuestion) return Combo;
            if (item is CheckBoxQuestion) return Check;
            return null;
        }
    }

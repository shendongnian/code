    public class TextBoxEx : TextBox
    {
        public TextBoxEx()
        {
            TextChanged += (sender, args) =>
                               {
                                   var bindingExpression = GetBindingExpression(TextProperty);
                                   if (bindingExpression != null)
                                   {
                                       bindingExpression.UpdateSource();
                                   }
                               };
        }
    }

    public class customtextbox : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            TextBox.TextProperty.AddOwner(typeof(customtextbox));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }

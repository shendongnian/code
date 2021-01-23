    public partial class Page : UserControl {
        
        private TextBox TextBox1;
        
        public Page() {
            InitializeComponent();
            TextBox1 = new TextBox();
            Width = 300;
            Height = 100;
            LayoutRoot.Children.Add(textbox);
            OnTextChanged(((object)(sender)), ((TextChangedEventArgs)(e)));
            TextBox1.TextChanged;
            if (e.Key == Key.Back) {
                e.Handled = true;
            }
            else if (e.Key == Key.Delete) {
                e.Handled = true;
            }
        }
    }

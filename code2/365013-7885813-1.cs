    public partial class CardLayout : Window
    {
        private Page[] pages = new Page[] {new Page1(), new Page2()};
        public CardLayout()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            frame1.Content = pages[((ComboBox) sender).SelectedIndex];
        }
    }

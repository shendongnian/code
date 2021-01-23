    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                TextBox txtBox = e.Source as TextBox;
                if(txtBox != null)
                {
                    this.txtBlock.Text = txtBox.Text;
                    this.txtBlock.Background = new SolidColorBrush(Colors.LightGray);
                }
            }
        }
    }

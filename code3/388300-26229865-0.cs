    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            richTextBox1.AllowDrop = true;  
            labelSender.MouseDown += new MouseButtonEventHandler(labelSender_MouseDown)
        }
        private void labelSender_MouseDown(object sender, MouseButtonEventArgs e) {
            DragDrop.DoDragDrop((Label)sender, ((Label)sender).Content, DragDropEffects.Copy);
        }
    }

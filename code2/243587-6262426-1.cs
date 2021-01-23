    public partial class Mywindow : Window
    {
        public string MyProperty { get; set; }
        public MyWindow()
        {
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            MyProperty = "Some new text"; // Set the text to something new
            this.Close();
        }
    }

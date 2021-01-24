    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblInput.Foreground = Brushes.ForestGreen;
            lblResult.Foreground = Brushes.ForestGreen;
            lblTitel.Foreground = Brushes.ForestGreen;
            //use the PalindromeChecker as the default implementation
            PalindromeChecker = new PalindromeChecker();
        }
        public ICheckPalindrome PalindromeChecker { get; set; } //<--
        private void InputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = InputText.Text;
            bool isPalindrome = PalindromeChecker.IsPalindrome(text);
            OutputText.Text = text + (isPalindrome ? " is a palindrome" : " is NOT a palindrome");
            if (InputText.Text == string.Empty)
            {
                OutputText.Clear();
            }
        }
    }

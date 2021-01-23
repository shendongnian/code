    public partial class DetailedMessageBox : Form
    {
        public DetailedMessageBox()
        {
            InitializeComponent();
        }
        public static void ShowMessage(string content, string description)
        {
            DetailedMessageBox messageBox = new DetailedMessageBox();
            messageBox.ShowDialog();
        }
    }

    public partial class DetailedMessageBox : Form
    {
        public static void ShowMessage(string content, string description)
        {
            DetailedMessageBox messageBox = new DetailedMessageBox();
            messageBox.ShowDialog();
        }
    }

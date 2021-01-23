    public partial class WaitForm : Form {
        private WaitForm() {
            InitializeComponent();
        }
        private static WaitForm instance;
        private static Stack<string> messages = new Stack<string>();
        public static void ShowMessage(string message) {
            if (messages.Count == 0) {
                instance = new WaitForm();
                instance.Show();
                instance.Update();
            }
            messages.Push(message);
            instance.lblMessage.Text = message;
        }
        public static void CloseForm() {
            messages.Pop();
            if (instance == null) return;
            if (messages.Count == 0) {
                instance.Close();
                instance = null;
            }
            else {
                instance.lblMessage.Text = messages.Peek();
            }
        }
    }

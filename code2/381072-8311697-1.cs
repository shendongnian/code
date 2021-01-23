    public partial class WaitForm : Form {
        private WaitForm() {
            InitializeComponent();
        }
        private static WaitForm instance;
        private static Stack<string> messages = new Stack<string>();
        public static void ShowMessage(string message) {
            if (instance == null) {
                instance = new WaitForm();
                instance.FormClosed += delegate { instance = null; };
                instance.Show();
            }
            messages.Push(message);
            instance.lblMessage.Text = message;
            instance.Update();
        }
        public static void CloseForm() {
            messages.Pop();
            if (instance != null) {
                if (messages.Count == 0) instance.Close();
                else instance.lblMessage.Text = messages.Peek();
            }
        }
    }

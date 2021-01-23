    public partial class Form1 : Form, IGlobalNotification {
        public Form1() {
            InitializeComponent();
            GlobalMessages.Register(this);
        }
        void IGlobalNotification.OnMessage(MyEventArgs arg) {
            // do something
        }
    }

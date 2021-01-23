    public partial class Publisher : Form
    {
        public event PostUpdateHandler OnPostUpdate;
        public Publisher()
        {
            InitializeComponent();
            new Subscriber(this).Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (OnPostUpdate != null)
            {
                OnPostUpdate(new PostUpdateArgs(textBox1.Text));
            }
        }
    }
    public delegate void PostUpdateHandler(PostUpdateArgs args);
    public class PostUpdateArgs : EventArgs
    {
        public string UpdateText;
        public PostUpdateArgs(string s)
        {
            UpdateText = s;
        }
    }

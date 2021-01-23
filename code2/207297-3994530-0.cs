    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public event EventHandler MyCustomClickEvent;
        protected virtual void OnMyCustomClickEvent(EventArgs e)
        {
            // Here, you use the "this" so it's your own control. You can also
            // customize the EventArgs to pass something you'd like.
            if (MyCustomClickEvent != null)
                MyCustomClickEvent(this, e);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            OnMyCustomClickEvent(EventArgs.Empty);
        }
    }

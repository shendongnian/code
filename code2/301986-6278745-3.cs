    public partial class WebForm1 : System.Web.UI.Page
    {
        public event EventHandler<btnEventArgs> SampleEvent;
        public void DemoEvent(int val)
        {
            // Copy to a temporary variable to be thread-safe.
            EventHandler<btnEventArgs> temp = SampleEvent;
            if (temp != null)
                temp(this, new btnEventArgs { btnNumber = val });
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Click += new EventHandler(Button1_Click);
        }
        void Button1_Click(object sender, EventArgs e)
        {
            DemoEvent(2);
        }
    }
    class btnEventArgs : EventArgs 
    {
        public int btnNumber { get; set; } 
    }

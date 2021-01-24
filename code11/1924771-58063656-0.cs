    public class MyLabel : Label
    {
        public MyLabel()
        : base()
        {
            Click += ProcessClickEvent;
        }
        private void ProcessClickEvent(object sender, System.EventArgs e)
        {
            // Do what you want to do
        }
    }

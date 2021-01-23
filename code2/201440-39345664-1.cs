    public class MyForm : Form
    {
        private static MyForm alreadyOpened = null;
        
        public MyForm()
        {
            // The "MdiParent nullcheck" is just in case the old form was closed too.
            // If not already disposed, at least the MdiParent property will be null.
            // Instead you could set "alreadyOpened" to null, in the closing handler.
            if (alreadyOpened != null && alreadyOpened.MdiParent != null)
            {
                alreadyOpened.Focus();            // Activate the old one and
                Shown += (s, e) => this.Close();  // close this new instance.
                return;
            }
            alreadyOpened = this;
            // Initialization
            InitializeComponent();
        }
    }

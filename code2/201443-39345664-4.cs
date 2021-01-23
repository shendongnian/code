	public class MyForm : Form
	{
		private static MyForm alreadyOpened = null;
		public MyForm()
		{
		    // If the form already exists, and has not been closed
			if (alreadyOpened != null && !alreadyOpened.IsDisposed)
			{
				alreadyOpened.Focus();            // Bring the old one to top
				Shown += (s, e) => this.Close();  // and destroy the new one.
				return;
			}			
            // Otherwise store this one as reference
			alreadyOpened = this;  
            // Initialization
            InitializeComponent();
		}
	}

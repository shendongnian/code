    namespace Server
    {
    	public delegate void Logs(string message);
    
    	public partial class Menu : Form
    	{
    		public Menu()
    		{
    			InitializeComponent();
    		}
    
    		private void InitializeComponent()
    		{
    			throw new NotImplementedException();
    		}
    
    		public void Log(string message)
    		{
    			if (InvokeRequired)
    			{
    				Invoke(new Action<string>(Log), message);
    				return;
    			}
    			else
    			{
    				this.tbLog.Text += DateTime.Now + ": " + message + Environment.NewLine;
    			}
    		}
    }

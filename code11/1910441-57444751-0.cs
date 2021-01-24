    public partial class Form1 : Form
    {
    	private Timer _timer;
    
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		_timer.Interval = 200;
    		_timer.Tick += _timer_Tick;
    		_timer.Enabled = true;
    		_timer.Start();
    	}
    
    	private void _timer_Tick(object sender, EventArgs e)
    	{
            // This function will be called every 200 ms.
    		// Read the information from port, update the UI.
    		string a = port.ReadExisting();
    		afisare.Text = a;
    	}
    
    	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    	{
    		_timer.Stop();
    
    		if (port != null && port.IsOpen)
    		{
    			port.Close();
    		}
    	}
    }

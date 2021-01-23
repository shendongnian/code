    public partial class Form1 : Form
    {
    	private bool _isRunning;
    
    	public Form1()
    	{
    		InitializeComponent();
    		txtValue.Text = @"0";
    
    		btnTest.MouseDown += (sender, args) =>
    		{
    			_isRunning = true;
    			Run();
    		};
    
    		btnTest.MouseUp += (sender, args) => _isRunning = false;
    	}
    
    	private void Run()
    	{
    		Task.Run(() =>
    		{
    			while (_isRunning)
    			{
    				var currentValue = long.Parse(txtValue.Text);
    				currentValue++;
    				txtValue.Invoke((MethodInvoker) delegate
    				{
    					txtValue.Text = currentValue.ToString();
    				});
    			}
    		});
    	}
    }

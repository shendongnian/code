    public partial class Form1 : Form
    {
    	BackgroundWorker _worker;
    	public Form1()
    	{
    		InitializeComponent();
    		_worker = new BackgroundWorker();
    		_worker.WorkerReportsProgress = true;
    		_worker.DoWork += _worker_DoWork;
    		_worker.ProgressChanged += _worker_ProgressChanged;
    	}
    
    	private void _worker_ProgressChanged( object sender, ProgressChangedEventArgs e )
    	{
    		label1.Text = e.UserState.ToString();
    	}
    
    	private void _worker_DoWork( object sender, DoWorkEventArgs e )
    	{
    		for( int i = 0; i < 100; ++i )
    		{
    			_worker.ReportProgress( i, i );
    			// allow some time between each update,
    			// for demonstration purposes only.
    			System.Threading.Thread.Sleep( 15 );
    		}
    	}	
    
    	private void button1_Click( object sender, EventArgs e )
    	{
    		_worker.RunWorkerAsync();
    	}
    }

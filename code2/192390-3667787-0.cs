    public class CustomEventWatcher : MRhinoEventWatcher
    {
    	MainUI _mainUI = null;
    	public MainUI MainWindow { get { return _mainUI; } set { _mainUI = value; } }
    
    	public override void OnReplaceObject(ref MRhinoDoc doc, ref MRhinoObject old, ref MRhinoObject obj)
    	{
    	   if(_mainUI != null)
    		   _mainUI.Whatever();
    	}
    }
    
    public partial class Splash : Form
    {
    	public Splash()
    	{
    		InitializeComponent();
    	}
    
    	private void timer1_Tick(object sender, EventArgs e)
    	{
    		this.Close();
    
    		MainUI MainWindow = new MainUI();
    		CustomEventWatcher cew = new CustomEventWatcher();
    		cew.MainWindow = MainWindow;
    		MainWindow.Show();
    	}
    }

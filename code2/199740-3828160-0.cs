    public class Program : MyBaseClass
    {
    	[STAThread]
    	static void Main()
    	{
    		MethodToDoAllTheHardWork();
    
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(new Form1());
    	}
    }
    
    public class MyBaseClass
    {
    	public static void MethodToDoAllTheHardWork()
    	{
    	}
    }

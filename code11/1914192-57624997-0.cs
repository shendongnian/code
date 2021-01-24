    [STAThread]
    static void Main(string [] args)
    {
    	if (args.Length > 0)
    	{              
    		Console.WriteLine("Yo!");
    		Console.ReadKey();
    	}
    	else
    	{
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(new Form1());
    	}                
    }

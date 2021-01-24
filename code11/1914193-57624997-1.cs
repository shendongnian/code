    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();
    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
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
            ShowWindow(GetConsoleWindow(), 0);
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(new Form1());
    	}                
    }

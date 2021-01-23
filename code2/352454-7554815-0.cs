    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        SplashImageForm f = new SplashImageForm();
        f.Shown += new EventHandler((o,e)=>{
			System.Threading.Thread.Sleep(2000);
			f.Close();
		});
        Application.Run(f);
        Application.Run(new Form1());
    }

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        SplashImageForm f = new SplashImageForm();
        f.Shown += new EventHandler((o,e)=>{
			System.Threading.Thread t = new System.Threading.Thread(() =>
				{
					System.Threading.Thread.Sleep(2000);
					f.Invoke(new Action(() => { f.Close(); }));
					
				});
				t.IsBackground = true;
				t.Start();
		});
        Application.Run(f);
        Application.Run(new Form1());
    }

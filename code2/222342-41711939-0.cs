    static void Main(string[] args)
    {
    // cancellation by keyboard string
    	CancellationTokenSource cts = new CancellationTokenSource();
    	// thread that listens for keyboard input
    	var kbTask = Task.Run(() =>
    	{
    		while (true)
    		{
    			key = Console.ReadKey(true);
    			if (key.KeyChar == 'x' || key.KeyChar == 'X')
    			{
    				cts.Cancel();
    				break;
    			}
    			else if (key.KeyChar == 'W' || key.KeyChar == 'w')
    			{
    				if (duty < 10)
    					duty++;
    				//Console.WriteLine("\tIncrementa Ciclo");
    				//mainAppState = StateMachineMainApp.State.TIMER;
    				//break;
    			}
    			else if (key.KeyChar == 'S' || key.KeyChar == 's')
    			{
    				if (duty > 0)
    					duty--;
    				//Console.WriteLine("\tDecrementa Ciclo");
    				//mainAppState = StateMachineMainApp.State.TIMER;
    				// break;
    			}
    		}
    	});
    
    	// thread that performs main work
    	Task.Run(() => DoWork(), cts.Token);
    
    	string OsVersion = Environment.OSVersion.ToString();
    	Console.WriteLine("Sistema operativo: {0}", OsVersion);
    	Console.WriteLine("Menú de Progama:");
    	Console.WriteLine(" W. Aumentar ciclo útil");
    	Console.WriteLine(" S. Disminuir ciclo útil");
    	Console.WriteLine(" X. Salir del programa");
    
    	Console.WriteLine();
    	// keep Console running until cancellation token is invoked
    	kbTask.Wait();
    }
    static void DoWork()
    {
    	while (true)
    	{
    		Thread.Sleep(50);
    		if (counter < 10)
    		{
    			if (counter < duty)
    				Console.Write("─");
    				//Console.WriteLine(counter + " - ON");
    			else
    				Console.Write("_");
    				//Console.WriteLine(counter + " - OFF");
    			counter++;
    		}
    		else
    		{
    			counter = 0;
    		}
    	}
    }

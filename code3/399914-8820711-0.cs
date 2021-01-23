        if ( windows_app )
        {
          Application.EnableVisualStyles(); 
          Application.SetCompatibleTextRenderingDefault(false); 
          Application.Run(new Form1());
        }
        else
        { 
            AllocConsole();
            Console.WriteLine( "foo" );
        }

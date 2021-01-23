        static void Main(params string[] args)
        {
            if (args.Length > 0 && args[0] == "consolemode")
            {
                // do stuff 
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

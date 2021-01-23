    [STAThread]
        static void Main(/*string[] args*/)
        {
            string[] args = Environment.GetCommandLineArgs();
            Console.WriteLine(args.Length);
            if (args.Length <= 1)
            {
                //calling gui part
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ACVSAppForm());
            }
            else
            {
                //calling cli part                
                string opt = args[1];
                //Console.WriteLine(args[0]);                
                if(opt == "LastBuild")
                {
                    if(args.Length == 3)
                    {
                        var defSettings = Properties.Settings.Default;
                        defSettings.CIBuildHistPath = args[2];
                    }
                    else
                    {
                        //
                    }
                    CIBuildParser cibuildlst = new CIBuildParser();
                    cibuildlst.XMLParser();
                }
            }
            
        }

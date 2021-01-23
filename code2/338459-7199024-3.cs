    [STAThread]
    static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            Application.Run(new MyMainForm());
        }
        else
        {
            // Do command line/silent logic here...
        }
    }

    static void Main()
    {
        using(frmLogin frmLogin_ = new frmLogin()) { //create new login form
           frmLogin_.ShowDialog(); //show i
           if (frmLogin_.DialogResult == DialogResult.Cancel) //if user pressed cancel
           {
               return; // This exits your application
           }
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new frmMainMDI()); //this is the line that bugs out
    }

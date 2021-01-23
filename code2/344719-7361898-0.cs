    static void Main()
    {
        Application.ThreadException += ExceptionHandler;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Forms.frmKDP_Main());
    }
    static void ExceptionHandler(object sender, ThreadExceptionEventArgs e)
    {
      const string errorFormat = @"some general message that a error occured";
      //error logging, usual log4.net
      string errMessage = string.Format(errorFormat, e.Exception.Message, e.Exception.StackTrace)
      DialogResult result = MessageBox.Show(, "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
      if (result == DialogResult.No)
      {
        Application.Exit();
      }
    }

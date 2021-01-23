    static class Program
    {
       /// <summary>
       /// The main entry point for the application.
       /// </summary>
       [STAThread]
       static void Main()
       {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
    
          SignInForm frmSignIn = new SignInForm();
          if (frmSignIn.ShowDialog() == DialogResult.Yes)
          {
             //If the sign-in completed successfully, show the main form
             //(otherwise, the application will quit because the sign-in failed)
             Application.Run(new ControlPanelForm());
          }        
       }
    }

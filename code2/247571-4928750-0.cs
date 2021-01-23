    static void Main()
    {
      if (!ControlFacade.CheckIfStkIsLaunched())
      { 
    
            DialogResult dlgResult = 
                MessageBox.Show("STK application not running. UavController will now close.", "Closing...",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
    
            Application.Exit();
            return;
      } 
    
      Application.Run(new UavControlForm());
    }
  

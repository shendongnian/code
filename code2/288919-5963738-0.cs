    public void Timer1_Tick(System.Object sender, System.EventArgs e)
      {
      var bgw = new BackGroundWorker();
      bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
      }  
 
    void bgw_DoWork(object sender, DoWorkEventArgs e)
      {
      // Put you try-catch block here.
      }
 

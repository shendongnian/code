    private void someVoid()
    {
         lbl_authenticationProcess.Text = "Credentials have been verified authentic...";
         lbl_authenticationProcess.Visible = true;
         Thread sleepThreadStart = new Thread(new ThreadStart(newThread_restProgram));
         sleepThreadStart.Start();
    }
    
    private void newThread_restProgram()
    {
         System.Threading.Thread.Sleep(3000);
         if (lbl_authenticationProcess.InvokeRequired) {
             lbl_authenticationProcess.Invoke(new SimpleCallBack(makeInvisible));
         } else {
             makeInvisible();
         }
    }
    private void makeInvisible()
    {
         lbl_authenticationProcess.Visible = false;
    }

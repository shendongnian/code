    private bool m_stop;
    private void button1_Click (object s, EventArgs ea)
    {
       try
       {
       //  Don't forget to disable all controls except the ones you want a user to be able to click while your method executes.
    
          toGet = textbox1.Text;
          got = 0;
       
          while (got <= toGet)
          {
            Application.DoEvents (); 
            // DoEvents lets other events fire.  When they are done, resume.
            if (m_stop)
               break;
            //DoStuff
          }
    
       finally
       {
          //  Enable the controls you disabled before.
       }
    }
    
    private void button2_Click (object s, EventArgs ea)
    {
       m_stop = true;
    }

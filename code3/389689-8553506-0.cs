    private void wait(int ms)
    {
       for(int x=0;x<ms;x++)
       {
          Thread.Sleep(1);
          System.Windows.Forms.Application.DoEvents();
       }
    }

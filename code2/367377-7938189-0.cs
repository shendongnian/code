    private bool CopyDone()
    {
      bool done = false;
      int i = 0;
      while (i < 5)
      {
        try
        {
          System.IO.File.Copy(source, target, true);
          i = 5;
          done = true;
        }
        catch (Exception exp)
        {
          Trace.WriteLine("File trouble " + exp.Message);
          System.Threading.Thread.Sleep(1000);
          i++;
        }
        return done;
      }
    }

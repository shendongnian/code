    private void IfsFileUpload(object sender, System.IO.FileSystemEventArgs e)
    {
      bool done = false;
      string file = e.FullPath;
      int i = 0;
      while (i < 5)
      {
        try
        {
          System.IO.File.Delete(file);
          i = 5;
          done = true;
        }
        catch (Exception exp)
        {
          System.Diagnostics.Trace.WriteLine("File trouble " + exp.Message);
          System.Threading.Thread.Sleep(1000);
          i++;
        }
      }
      if (!done)
        MessageBox.Show("Failed to delte file " + file);
    }

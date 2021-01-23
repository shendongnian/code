    {
       try 
       {
          System.Diagnostics.Process.Start("WINRAR.EXE");
       }
       catch(Exception exc)
       {
           // handle exception, e.g. possibly log it to a file or database, or do something else
           MessageBox.Show(exc.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
    }

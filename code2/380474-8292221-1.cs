    try
    {
       System.Diagnostics.Process.Start("WINWORD.EXE");
    }catch(Exception ex)
    {
       MessageBox.Show(ex.getMessage());
    }

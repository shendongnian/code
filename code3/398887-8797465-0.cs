    public void DoStuff(String filename)
    {
        try {
           // Some file I/O here...
        }
        catch (IOException ex) {
          // Add filename to the IOException
          ex.Data.Add("Filename", filename);
          // Send the exception along its way
          throw;
        }
    }

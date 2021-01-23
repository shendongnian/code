    public static void WaitForFile(System.String file)
    {
        // While the file is in use...
        while (FileInUse(file))
        {
            // We wait!
            System.Windows.Forms.Application.DoEvents(); // But we may not freeze the UI!
                                    // If we use a modal form, f.e.
        }
    }
  

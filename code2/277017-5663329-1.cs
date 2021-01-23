    private void ImagePanel_Drop(object sender, DragEventArgs e)
    {
    
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        // Note that you can have more than one file.
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
        // Assuming you have one file that you care about, pass it off to whatever
        // handling code you have defined.
        HandleFileOpen(files[0]);
      }
    }

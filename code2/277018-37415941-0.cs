    RtbInputFile.Drop += RtbInputFile_Drop;            
    RtbInputFile.PreviewDragOver += RtbInputFile_PreviewDragOver;
    
    private void RtbInputFile_PreviewDragOver(object sender, DragEventArgs e)
    {
        e.Handled = true;
    }
    
    private void RtbInputFile_Drop(object sender, DragEventArgs e)
    {
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
         {
                    // Note that you can have more than one file.
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    var file = files[0];                
                    HandleFile(file);  
         }
    }

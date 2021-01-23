    IDataObject d = Clipboard.GetDataObject();
    if(d.GetDataPresent(DataFormats.FileDrop))
    {
        //This line gets all the file paths that were selected in explorer
        string[] files = d.GetData(DataFormats.FileDrop);
        //Get the name of the file. This line only gets the first file name if many file were selected in explorer
        string TheImageFile = files[0];
        //Use above method to check if file is Image file
        if(IsAnImage(TheImageFile))
        {
             //Process file if is an image
        }
        {
             //Process file if not an image
        }
    }

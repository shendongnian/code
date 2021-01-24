    ...
    else //file already existing by that name, update it's contents
    {
        // Gets the media file
        MediaFileInfo updateFile = mediaFiles.FirstObject;
        updateFile.Delete(); // DELETE IT
        using (StreamReader streamReader = new StreamReader(outputFilename))
        {
            MediaFileInfo updateFile = new MediaFileInfo();
            //Set here all properties
            updateFile.FileBinaryStream = streamReader.BaseStream;
            updateFile.FileSize = streamReader.BaseStream.Length;
            // Saves the media library file
            MediaFileInfoProvider.SetMediaFileInfo(updateFile);
        }
    }

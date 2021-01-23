    string blaFile = "C:\TextFile.txt"; // The text file that we want to read.
    
    private void FilesystemWatcher_Changed(....).... // The FilesystemWatcher_Changed event notifies us when a file on the monitored path (FilesystemWatcher.Path) has changed. When a file has changed the code within this event gets executed.
    {
        if (e.File == blaFile) // We check if the file that has chenged, is the one we want.
        {
            RichTextBox.LoadFile(blaFile); // It is! We load it into the RichtextBox again so that it's "up-to-date"!
        }
    }

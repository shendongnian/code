    IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
    if (!isf.FileExists("my.db"))
    {
        StreamResourceInfo sri = App.GetResourceStream(new Uri("my.db", UriKind.Relative));
        IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("my.db", FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication());
        long FileLength = (long)sri.Stream.Length;
        byte[] byteInput = new byte[FileLength];
        sri.Stream.Read(byteInput, 0, byteInput.Length);
        isfs.Write(byteInput, 0, byteInput.Length);
        sri.Stream.Close();
        isfs.Close();
    } 

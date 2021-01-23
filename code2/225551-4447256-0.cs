    string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test/song.mp3");
    
             
                media.SetSource(new FileStream(path, FileMode.Open));
                media.Position = TimeSpan.Zero;
                media.Play();

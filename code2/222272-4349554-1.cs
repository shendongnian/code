    private void FindAlbums(string root)
    {
        // Find all the albums
        string[] folders = Directory.GetDirectories(root);
        foreach (string folder in folders)
        {
            if (this.Stop)
            {
                break;
            }
            string[] files = Directory.GetFiles(folder, "*.mp3");
            if (files.Length > 0)
            {
                // Add to library - use first file as being representative of the whole album
                var info = new AlbumInfo(files[0]);
                this.musicLibrary.Add(info);
                if (this.Library_AlbumAdded != null)
                {
                    this.Library_AlbumAdded(this, new AlbumInfoEventArgs(info));
                }
            }
            this.FindAlbums(folder);
        }
    }

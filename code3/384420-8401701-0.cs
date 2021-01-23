     private string artistName;        
     public string ArtistName
        {
            get
            {
                return artistName;
            }
            set
            {
                artistName = value;
            }
        }
    clsDataConduit track = new clsDataConduit();
    track.Execute("sporc_tbltrack_GetAll");
    track.NewRecord["artistname"] = artistName;

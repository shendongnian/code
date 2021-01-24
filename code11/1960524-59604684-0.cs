    private List<string> _photos = null;
    private string _dirPhotos = null;
    [Column("dir_fotos")]
    public String DirPhotos 
    { 
        get { return _dirPhotos; }
        set
        { 
            if(string.Compare(_dirPhotos, value, true) != 0)
            {
                _dirPhotos = value;   
                _photos = null;
            }
        }
    }
    [NotMapped]
    public List<String> photos
    {
        get { return _photos ?? (_photos = GetPhotos(DirPhotos) ); }
    }

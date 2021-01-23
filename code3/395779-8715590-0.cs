    public ICommand _CreateAlbum
    {
        get
        {
            if (createAlbum == null)
                createAlbum = new Model.DelegateCommand(CreateAlbum, CanAdd);
            return createAlbum;
        }
        set
        {
            createdAlbum = value; // or something else sensible!
        }
    }

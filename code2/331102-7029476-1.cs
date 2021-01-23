    interface IAlbumContext
    {
        public AlbumInfo SelectedAlbum { get; set; }
    }
    
    class AlbumContext
    {
        AlbumSelectionViewModel _model;
    
        public AlbumContext(AlbumSelectionViewModel model)
        {
            _model = model;
        }     
    
        public Album SelectedAlbum {
            get { return _model.Album; }
        }
    }
    
    class PhotoUploadDialog : Dialog
    {
        public PhotoUploadViewModel(IAlbumContext context, PhotoUploadViewModel viewModel)
        {
        }
    }

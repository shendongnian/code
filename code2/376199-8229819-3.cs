    public class ImageFileService : IImageFileService
    {
        public ImageFileService(IImageLinkMapRepository repository)
        {
            // null checks etc. left out for brevity
            _repository = repository;
        }
        public void RenameFiles()
        {
            // rename files, using _repository.GetImageLinks(), which encapsulates
            // enough information for it to do the rename operations without this
            // class needing to know the specific details of the source/dest dirs.
        }
        public void CopyFiles() 
        { 
            // same deal as above
        }
    }

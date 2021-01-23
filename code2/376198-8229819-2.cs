    public interface IImageFileService
    {
        void RenameFiles();
        void CopyFiles(); 
    }
    public interface IImageLinkMapRepository
    {
        IList<ImageLink> GetImageLinks(); 
    }

    public class AnnouncementSaver {
    
      private ITest config;
      public AnnouncementSaver(ITest config) {
        // inject it
        this.config = config;
      }
    
      private string SaveAnnouncement (IFormFile file = null, string base64 = null) {
        // use it
        config.GetFolders("FolderAnnouncement");
      }
    
    }

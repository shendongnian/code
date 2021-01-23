    public interface INewFilenameService {
      string FileName {get;set;}
    }
    
    public class ContentType {
        private INewFilenameService newFilenameService;
    
        public ContentType(INewFilenameService service) {
            this.newFilenameService = service;
        }
    
        public string ContentName { get; set; }
        public string FolderName { get; set; }
        public bool RenameFile { get; set; }
        public bool HasMultiple { get; set; }
    
        public string GetNewFilename() {
          return service.Filename;
        }
    }

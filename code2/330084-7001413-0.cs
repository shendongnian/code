    public interface IDirectoryService {
        string MapPath(string relative);
    }
    
    public DirectoryService : IDirectoryService {
        public string MapPath(string relative)
        {
            return Server.MapPath(relative);
        }
    }

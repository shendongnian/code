    public class Folder 
    {     
        public int Id { get; set; }     
        public string Name { get; set; } }  
    
        // Try to avoid exposing data structure implementations publicly
        private Folder[] _folders = new Folder[] {};  
    
        public IEnumerable<Folder> Folders 
        {
            get 
            {
                return this._folders;
            }
        }
    
        public IEnumerable<int> FolderIds 
        {
            get 
            {
                // Linq knows all
                return this._folders.Select(f => f.Id);
            }
        }
    }

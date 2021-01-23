    public class Album
    {
        public class AlbumConfiguration : EntityTypeConfiguration<Album> 
        {
            public AlbumConfiguration()
            {
                // Inner class will see private members of the outer class
                HasMany(a => a._photos)...
            }
        }
    
        private readonly ICollection<Photo> _photos = new List<Photo>();
        public string Name {get; set;}
        public virtual IEnumerable<Photo> Photos
        {
            get{ return _photos;}
        }
    
        public void AddPhoto(byte[] bytes, string name)
        {
            //some biz rules
            Photo p = new Photo();
            p.Bytes = bytes;
            p.Name = name;
            _photos.Add(p);
        }
    }

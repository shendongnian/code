    public class Memes
    {
        public int MemesId { get; set; }
        public string MemName { get; set; }
        public string UserId { get; set; }
        public string Image { get; set; }
        public List<HashTag> HashTags { get; set; }
    }
    public class HashTag
    {
        public int HashTagId { get; set; }
        public int MemesId { get; set; }
        public string Name { get; set; }
    
        public virtual Memes { get; set; }
    }
    

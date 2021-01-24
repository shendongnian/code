    public enum EntityType{
        Game = 1,
        Lecture = 2,
        Course = 3
    }
    
    public class MyEntity : ModelBase{
        private ICollection<FileInEntity> Icons { get; set; } = new List<FileInEntity>();
    
        [NotMapped]
        public File Image => Icons.Select(e => e.File).FirstOrDefault();
    
        public EntityType EntityType {get;set;} //course, lecture, or  game
    }

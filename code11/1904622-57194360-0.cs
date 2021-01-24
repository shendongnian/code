    public class ModelBase
    {
        [Key]// add for primary key
        //set none always for primary keys (because guid has no auto increment)
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public Guid Id { get; set; }
    }
    [Table("Files")]
    public class File : ModelBase
    {
        //make it public
        public ICollection<FileInEntity> FileInEntities { get; set; } = new List<FileInEntity>(); 
    
        [NotMapped] //set not mapped
        public IEnumerable<ModelBase> Entities => FileInEntities.Select(e => e.Entities);
        //do it same changes for `Lacture.cs`, `Game.cs` and `Course.cs`...
    }

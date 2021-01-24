    [Table("Requests")]
    public class Request
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<DiaryEntry> Diary { get; protected set; } = new List<DiaryEntry>();
    }
    [Table("DiaryEntries")]
    public class DiaryEntry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiaryEntryId { get; set; }
        public string Value { get; set; }
        public virtual Request Request { get; set; }
    }

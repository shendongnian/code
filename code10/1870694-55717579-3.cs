    [Table("Assignee")]
    public class Assignee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("AssigneeID")]
        public int AssigneeId { get; set; }
    }

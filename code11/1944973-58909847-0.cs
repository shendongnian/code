    [Table(name: "Status")]
    public class Status : FullAuditedEntity<string>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Guid]
        public override Guid Id { get; set; }

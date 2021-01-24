c#
public class Subject
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SubjectId { get; set; }
    [Required]
    public virtual long EnrolledFaceId {get;set;} //
    [ForeignKey("EnrolledFaceId")]
    public virtual FaceImage EnrolledFace {get;set;}
    
    [Required]
    public DateTimeOffset EnrolledTime { get; set; }
    [Required]
    [Column(TypeName = "varchar")]
    [StringLength(64)]
    public string BiometricId { get; set; }
    public virtual ICollection<KVPair> KeyValues { get; set; }
    public Subject()
    {
        KeyValues = new List<KVPair>();
    }
}
c#
[Table("SubjectFaces")]
public class FaceImage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid FaceId { get; set; }
    //Add a reference to the Subject
    [Required]
    public Subject Subject { get; set; }
    public long SubjectId { get; set; }
    [Required]
    public byte[] Image { get; set; }
}
c#
[Table("SubjectData")]
public class KVPair
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid KvPairId { get; set; }
    //Add a reference to the Subject
    [Required]
    public long SubjectId { get; set; }
    [ForeignKey("SubjectId")]
    public Subject Subject { get; set; }
    [Required]
    [Column(TypeName = "varchar")]
    [StringLength(128)]
    public string Key { get; set; }
    [Column(TypeName = "varchar")]
    [StringLength(128)]
    public string Value { get; set; }
}
  [1]: https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx

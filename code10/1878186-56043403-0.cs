public partial class Applicant
{
    [Key]
    public int ApplicantID { get; set; }
    public string ApplicationSource { get; set; }
    public string Gender { get; set; }
    public virtual ICollection<AttachedDocuments> AttachedDocuments { get; set; }
}
public partial class AttachedDocuments
{
    [Key]
    public int AttachedDocID { get; set; }
    public int ApplicantID { get; set; }
    public string AttechedDocGUID { get; set; }
    public int DocumentTypeID { get; set; }
    [ForeignKey("ApplicantID")]
    public virtual Applicant Applicant { get; set; }
}

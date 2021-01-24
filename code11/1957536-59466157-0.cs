c# public class Event : BaseEntity
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int? ClientId { get; set; }
    [ForeignKey("ClientId ")]
    public virtual Client Client { get; set; }
}

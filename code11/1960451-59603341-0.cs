 c#
 public class Refmodel
{
    public int Id { get; set; }
    public string Ref { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
}

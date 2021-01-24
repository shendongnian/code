    public class GroupMember: BaseEntity
    {
    public User User { get; set; }
    [Key, Column(Order = 0)]
    public int UserId { get; set; }
    public Group Group { get; set; }
    [Key, Column(Order = 1)]
    public int GroupId { get; set; }
    }

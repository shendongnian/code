c#
public class EFUser
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public ICollection<EFNotification> Notifications { get; set; }
}
public class Mapper // or use AutoMapper
{
    public EFUser Map(User user)
    {
        return new EFUser
        {
            UserName = user.UserName,
            Notifications = Map(user.Notifications)
        }
    }
}

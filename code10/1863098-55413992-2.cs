public string Email { get; set; }
[XmlIgnore]
public bool EmailSpecified { get; set; }
then `EmailSpecified` a: controls whether `Email` gets serialized, and b: it is *assigned* a value of `true` when deserialized from an active value. So: you can do something like:
 c#
public class Account
{
    public string Email { get; set; }
    [XmlIgnore]
    public bool EmailSpecified { get; set; }
    public bool Active { get; set; }
    [XmlIgnore]
    public bool ActiveSpecified { get; set; }
    public List<string> Roles { get; set; }
    [XmlIgnore]
    public bool RolesSpecified { get; set; }
    public DateTime CreatedDate { get; set; }
    [XmlIgnore]
    public bool CreatedDateSpecified { get; set; }
}
and then merge manually:
 c#
Account account = new Account
{
    Email = "james@example.com",
    Active = true,
    CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
    Roles = new List<string>
    {
        "User",
        "Admin"
    }
};
var xml = @"<Account>
<Active>false</Active>
</Account>";
using (var source = new StringReader(xml))
{
    var serializer = new XmlSerializer(typeof(Account));
    var merge = (Account)serializer.Deserialize(source);
    // this bit could also be done via reflection
    if (merge.ActiveSpecified)
    {
        Console.WriteLine("Merging " + nameof(merge.Active));
        account.Active = merge.Active;
    }
    if (merge.EmailSpecified)
    {
        Console.WriteLine("Merging " + nameof(merge.Email));
        account.Email = merge.Email;
    }
    if (merge.CreatedDateSpecified)
    {
        Console.WriteLine("Merging " + nameof(merge.CreatedDate));
        account.CreatedDate = merge.CreatedDate;
    }
    if (merge.RolesSpecified)
    {
        Console.WriteLine("Merging " + nameof(merge.Roles));
        account.Roles = merge.Roles;
    }
}

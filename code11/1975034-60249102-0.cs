cs
var userRoles = typeof(UserRoles).GetNestedTypes().SelectMany(t => t.GetProperties());
It returns enumeration of properties for every nested class in `UserRoles`.
But if you want to store some information like set of keys and values, [`Dictionary<TKey,TValue>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.8) is better choice, than static nested classes. Have a look at example below
cs
public enum UserType
{
    Administrator,
    ClientUser,
    Driver
}
public class UserInfo
{
    public string Code { get; set; }
    public string Title { get; set; }
}
...
var roles = new Dictionary<UserType, UserInfo>
{
    { UserType.Administrator, new UserInfo { Code = "ADMIN", Title = "Administrator" } },
    { UserType.Driver, new UserInfo { Code = "DR", Title = "Driver" } }
    //and so on
};
//get admin title
var title = roles[UserType.Administrator].Title;

public class User1 : IdentityUser
{
    public string UniqueStringProp { get; set; }
}
public class User2 : IdentityUser
{
    public int UniqueIntProp { get; set; }
}
In this case you call AddDefaultIdentity with the type parameter IdentityUser. You'll have a UserManager<IdentityUser> available.
In your DbContext you should write this in your OnModelCreating method:
protected override void OnModelCreating(ModelBuilder builder)
{
    builder.Entity<User1>()
        .HasBaseType<IdentityUser>();
    builder.Entity<User2>()
        .HasBaseType<IdentityUser>();
    base.OnModelCreating(builder);
}
This way you are telling EntityFramework that `User1` and `User2` are also subtypes of `IdentityUser` and it will put them into the same table (by default).
It will generate a table like this, which will have all the IdentityUser descendants:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/pFxjL.png
You can create users with the `UserManager<IdentityUser>` with your unique user type, since the methods require an `IdentityUser`, `User1` and `User2` are also IdentityUsers. However when you need to access the unique data of the users you need to type-check every time, because the query methods will only give you your users as `IdentityUser`. So if you wanted to access your `User1`'s stringProp you'd have to do like this:
var user = await userManager.FindByNameAsync("user1's username");
if (user is User1 user1)
{
    // Access user1's string property here
}

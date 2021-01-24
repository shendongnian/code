IDictionary<Permission, string> PermissionGroups = new Dictionary<Permission, string>
{
  { Permission.download, "Everyone" },
  { Permission.upload, "RegisteredUsers" }
};
I would say this is now synonymous with the typescript version, as it means your Check method can look like:
public void Check(User user, Permission permission)
{
  if (!user.Groups.Contains(PermissionGroups[permission]))
    throw new Exception("Access denied");
}
Your code implies that this comes from your config file, in which case this is just creating a new problem elsewhere.
I am purposefully avoiding the discussion about the possible ways to do role-based security.

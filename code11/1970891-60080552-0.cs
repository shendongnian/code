private static T QueryRepo<T>(Func<Repo, T> func)
{
    using (var repo = new Repo())
    {
        return func(repo);
    }
}
Allowing you to write:
public List<User> GetUsers(string userPath, string userName) =>
    QueryRepo(repo => repo.GetUsers(userPath, userName));

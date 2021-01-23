    public class User
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    public static IQueryable<User> WhereEquals(this IQueryable<User> source, User user)
    {
        // this is your implementation of the entity specific equality test
        return source.Where(x => x.Id == user.Id);
    }
    static void Main(string[] args)
    {
        var list = new List<User> { new User { Id = 1, Text = "User" } };
        var user = new User{ Id = 1 };
        var q = list.AsQueryable().WhereEquals(user);
        foreach (var item in q)
        {
            Console.WriteLine(item.Text);
        }
    }

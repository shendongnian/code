    public class Foo
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    public static IQueryable<Foo> WhereUserEquals(this IQueryable<Foo> source, User user)
    {
        // this is your implementation of the entity specific equality test
        return source.Where(x => x.User.Id == user.Id);
    }
    static void Main(string[] args)
    {
        var list = new List<Foo> { new Foo { User = new User { Id = 1, Text = "User" } };
        var user = new User { Id = 1 };
        var q = list.AsQueryable().WhereUserEquals(user);
        foreach (var item in q)
        {
            Console.WriteLine(item.Text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var createSql = @"
                create table #Users (UserId int, Name varchar(20))
                create table #Posts (Id int, OwnerId int, Content varchar(20))
                insert #Users values(99, 'Sam')
                insert #Users values(2, 'I am')
                insert #Posts values(1, 99, 'Sams Post1')
                insert #Posts values(2, 99, 'Sams Post2')
                insert #Posts values(3, null, 'no ones post')
            ";
            var sql =
            @"select * from #Posts p 
            left join #Users u on u.UserId = p.OwnerId 
            Order by p.Id";
            using (var connection = new SqlConnection(@"CONNECTION STRING HERE"))
            {
                connection.Open();
                connection.Execute(createSql);
                var data = connection.Query<Post, User, Post>(sql, (post, user) => { post.Owner = user; return post; }, splitOn: "UserId");
                var apost = data.First();
                apost.Content = apost.Content;
                connection.Execute("drop table #Users drop table #Posts");
            }
        }
    }
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
    class Post
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string Content { get; set; }
    }

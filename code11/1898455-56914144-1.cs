c#
 public static void Initialize(MyWebsiteContext context)
        {
            // Look for any authors; if none, seed DB.
            if (context.Author.Any())
            {
                return; // DB has already been seeded.
            }
            var authors = new Author[]
            {
                new Author{ FirstName="Terry",LastName="Pratchett",SignUpDate=DateTime.Parse("2019-04-01")},
                new Author{ FirstName="Neil",LastName="Gaiman",SignUpDate=DateTime.Parse("2019-03-02")},
            };
            foreach (Author a in authors)
            {
                context.Author.Add(a);
            }
            var posts = new Post[]
            {
                new Post{PostID=1,Title="Title of post 1" ,Author = authors[0] },
                new Post{PostID=2,Title="Title of post 2" ,Author = authors[0]},
                new Post{PostID=3,Title="Title of post 3" ,Author = authors[0]},
            };
            foreach (Post p in posts)
            {
                context.Post.Add(p);
            }
            context.SaveChanges();
        }
The first time it performs the SaveChange() operation successfully, but the second time it takes an error to add posts due to the lack of a foreign key of author, and the operation is not performed.
Always use one SaveChange

        public List<Post> posts;
        protected void Page_Load(object sender, EventArgs e)
        {
            posts = new List<Post>();
            posts.Add(new Post { PostDate = DateTime.Parse("2011-01-01"), PostName = "Post1", PostAddress = "www.post.com" });
            posts.Add(new Post { PostDate = DateTime.Parse("2011-01-02"), PostName = "Post2", PostAddress = "www.post.com" });
            posts.Add(new Post { PostDate = DateTime.Parse("2011-01-03"), PostName = "Post3", PostAddress = "www.post.com" });
            posts.Add(new Post { PostDate = DateTime.Parse("2011-01-04"), PostName = "Post4", PostAddress = "www.post.com" });
            posts.Add(new Post { PostDate = DateTime.Parse("2011-01-05"), PostName = "Post6", PostAddress = "www.post.com" });
            posts.Add(new Post { PostDate = DateTime.Parse("2011-01-06"), PostName = "Post7", PostAddress = "www.post.com" });
            // Load Posts into Control
            LoadxPosts(4);
        
        
        }
        private void LoadxPosts(int xPostNum)
        {
            var postxList = posts.OrderByDescending(x=> x.PostDate).Take(xPostNum);
            ListView1.DataSource = postxList;
            ListView1.DataBind();
        }
    }
    public class Post
    {
        public string PostName { get; set; }
        public DateTime PostDate { get; set; }
        public string PostAddress { get; set; }
    }
}

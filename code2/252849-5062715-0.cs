    public List<Post> posts;
    protected void Page_Load(object sender, EventArgs e)
    {
		posts = new List<Post>();
		posts.Add(new Post { ID = 1, Value = "Post 1" });
		posts.Add(new Post { ID = 2, Value = "Post 2" });
    }

    public partial class _Default : System.Web.UI.Page
    {
        private class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public string ImageUrl { get; set; }
        }
    protected void Page_Load(object sender, EventArgs e)
    {
        var userList = new[] {
            new User {Name = "user1", Password = "pass1", ImageUrl = "img1.jpg"},
            new User {Name = "user2", Password = "pass2", ImageUrl = "img2.jpg"},
            new User {Name = "user3", Password = "pass3", ImageUrl = "img3.jpg"},
        };
        Repeater1.DataSource = userList;
        Repeater1.DataBind();
    }

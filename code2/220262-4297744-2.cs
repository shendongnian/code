    public partial class Post : IData<Post>
    {
      public Post Select(int id)
      {
          MyDataContext dc = MyDataContext.Create();
          return dc.Posts.Single(p => p.PostID == id);
      }
      
      IData<Post> IData<Post>.Select(int id)
      {
          return Select(id);
      }
    
    }

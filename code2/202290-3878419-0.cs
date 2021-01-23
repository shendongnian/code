    [assembly: InternalsVisibleTo("MyLibrary.Repositories")]
    public class Post
    {
       public int PostId { get; internal set; }
       public int Name { get; internal set; }
          ...
    }

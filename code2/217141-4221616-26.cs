    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
       public void UpdateModel(Post post)
       {
          var originalPost = CurrentEntitySet.SingleOrDefault(p => p.PostId == post.PostId);
          Context.ApplyCurrentValues(GetEntityName<Post>(), post);
       }
    }

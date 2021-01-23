    public class PostRepository : GenericRepository<Post>
    {
       public PostRepository(IUnitOfWork uow) : base(uow)
       {
          UpdateComplexAssociations += 
                      new UpdateComplexAssociationsHandler<Post>(UpdateLocationPostRepository);
       }
    
       public UpdateLocationPostRepository(Post post)
       {
          // do some stuff to interrogate the post, then add to LocationPost.
       }
    }

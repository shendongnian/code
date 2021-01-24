public interface ISortPostsStrategy
{
    Task<IEnumerable<Post>> SortAsync(string userId);
}
public abstract class BaseTimeDependentPostSortingStrategy : ISortPostsStrategy
{
    private readonly DateTime _startDate;
    protected BaseTimeDependentPostSortingStrategy(DateTime startDate)
    {
        _startDate = startDate;
    }
    public abstract Task<IEnumerable<Post>> SortAsync(string userId);
}
public class SortPostsByNew : ISortPostsStrategy
{
    private readonly UnitOfWork unitOfWork;
    public SortPostsByNew(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Post>> SortAsync(string userId)
    {
        var dbPosts = await this.unitOfWork.Posts.GetBySubcribedUserOrderedByNewAsync(userId);
        return dbPosts;
    }
}
public class SortPostsByBest : BaseTimeDependentPostSortingStrategy 
{
    private readonly UnitOfWork unitOfWork;
    public SortPostsByBest(UnitOfWork unitOfWork, DateTime startDate) : base(startDate)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Post>> SortAsync(string userId)
    {
        var dbPosts = await this.unitOfWork.Posts.GetBySubscribedUserOrderedByBestAsync(userId, _startDate);
        return dbPosts;
    }
}
Disclaimer: This might not compile, I have not tested it.
If that doesn't answer your question, please provide additional information so that I may help.
  [1]: https://en.wikipedia.org/wiki/Dependency_injection

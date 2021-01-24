    public class Base
    {
    }
    public class Base<T> : Base
    {
    }
    public interface ICommentRepository<T> : IBaseRepository<T>
        where T : Base, new()
    {
    }

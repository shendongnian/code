    public interface IEntity
    {
        int Id { get; }
    }
    public class Region : IEntity { ... }
    public static class EntityExtensions
    {
        public static int GetIdOrZero(this IEntity entity)
        {
            return entity == null ? 0 : entity.Id;
        }
    }

    public class UrlRecordService
    {
        public virtual void SaveSlug<T>(T entity) where T : ISlugSupport
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
    
            int entityId = entity.Id;
            string entityName = typeof(T).Name;
        }
    }
    public interface ISlugSupport
    {
        int Id { get; set; }
    }

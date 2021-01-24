    public class AdPersister<TEntity> : IAdPersister<TEntity>
        where TEntity : AdBase {
        public AdPersister(IAdRepository<TEntity> adRepository, IAdImagePersister imagePersister) {
            //...
        }
    
        //...
    }

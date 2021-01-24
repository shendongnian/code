cs 
    public class MyEntity: Entity
    {
        public int Id { get; private set; }
        private IList<RelatedEntity> _relatedEntities = new List<RelatedEntity>();
        public IList<RelatedEntity> RelatedEntities 
        {
           get 
           { 
               _collection.ToList().AsReadOnly();
           }
       }

    You can use it in collaboration with your business layer like this:
    public class EntityManager()
    {
         public IQueryable<Entities> FindAllApprovedEntities(Entity other)
         {
              return new Repository().SelectAllEntityRelatedToAnotherEntity(other).Where(e=>e.Approved);
         }
    }

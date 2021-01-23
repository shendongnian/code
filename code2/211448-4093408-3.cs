    public class BaseEntityModel<T> : where T : IEntity2 // We use llblgen here
    {
         ... code
         // T is a generic type, which has to implement IEntity2
         // But we don't care what type it is
         public T Entity { get; set; }
         public void Save()
         {
               Entity.Save(); // Save is from IEntity2
         }
         ... code
    }

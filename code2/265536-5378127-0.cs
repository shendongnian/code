    public class CollectionBase<T> : IEnumerable<T>
      where T: EntityBase
    {
        protected EntityBase[] itemArray;
    
        //implementing the IEnumerable<EntityBase> is here. GetEnumerator method returns IEnumerator<EntityBase>
    
    }

    public static void MoveDisplayOrder<T>(IRepository<T> repository, int id, 
        bool moveUp) where T : IOrderedEntity
    {
      var currentStatus = repository.FindById(id);
      //...do reordering work
      repository.InsertOrUpdate(currentStatus);
    }

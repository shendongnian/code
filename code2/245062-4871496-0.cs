    class Repository<T> : IRepository<T>
    {
       public virtual T FindById(int id)
       { ... }
    }
    class FruitRepository<T> : Repository<T> where T : Fruit
    {
       public override T FindById(int id)
       {  ... }
    }
    class AppleRepository : FruitRepository<Apple>
    {
       public override T FindById(int id)
       {  ... }
    }

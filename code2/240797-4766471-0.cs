    interface IEntity
    {
        void Load(int Id);
    }
    class CBuyer: IEntity
    {
        public Load(int Id) { ... }
    }
    public T Get<T>(int PersonId) where T: IEntity, new()
    {
        T ent = new T();
        ent.Load(PersonId);
        return ent;
    }    

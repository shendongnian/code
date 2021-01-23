    struct Identifier<TEntity>
    {
        private int _id;
        public Identifier(int id)
        {
            _id = id;
        }
        public int Id { get { return _id; } }
        public static implicit operator int(Identifier<TEntity> identifier)
        {
            return identifier.Id;
        }
        public static implicit operator Identifier<TEntity>(int id)
        {
            return new Identifier<TEntity>(id);
        }
        // todo: implement compare logic
    }

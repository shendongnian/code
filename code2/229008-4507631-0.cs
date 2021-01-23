        public int Add(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _objectSet.AddObject(entity);
            SaveChanges();
            return entity.mytable_id;
        }

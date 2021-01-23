        public void Add(TModel entity1, TModel entity2)
        {
            if (entity1 == null || entity2 == null)
                throw new ArgumentNullException("entity");
            entity1.Table2 = entity2;
            _objectSet1.AddObject(entity1);
            _objectSet2.AddObject(entity2);
            SaveChanges();
        }

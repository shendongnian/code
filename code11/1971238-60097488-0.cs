        public List<TEntity> GetEntities<TEntity>(int[] ids)
        {
            var someDbSet = new DbSet<TEntity>();
            var resultQ = new List<your_list_type>();
            foreach( var id in ids) {
              resultQ.Add(someDbSet.Where(prm => prm.ID == id).FirstOrDefault());
    }
            return resultQ;
        
        }

        public T Add(T entity)
        {
            try
            {
                this.mongoCollection.InsertOne(entity);
                var response = this.mongoCollection.AsQueryable().OrderByDescending(c => c.Id).First();
                return response;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.ToString());
            }
        }

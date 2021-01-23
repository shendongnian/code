	/// <summary>
        /// Updates and entity and save it to the database.
        /// If it doesn't exist it creates a new entity and saves it to the database.
        /// <example>
        ///     <code>
        ///         //Updates or inserts a row into Account. The inserted/updated row will have its AccountNumber set to "17".
        ///         var account = db.Accounts.InsertOrUpdate(a => a.ID == id, a => a.AccountNumber = "17");
        ///     </code>
        /// </example>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="allEntities"></param>
        /// <param name="entityFilter"></param>
        /// <param name="propertySetter"></param>
        /// <returns></returns>
        public static TEntity InsertOrUpdate<TEntity>(this ObjectSet<TEntity> allEntities, Func<TEntity, bool> entityFilter,
                                                      Action<TEntity> propertySetter) where TEntity : class, new()
        {
            //First we use the entityValueMapper to search for an existing entity.
            var entity = allEntities.Where(entityFilter).FirstOrDefault();
            if (entity == null)
            {
                entity = new TEntity();
                allEntities.AddObject(entity);
            }
            propertySetter(entity);
            allEntities.Context.SaveChanges();
            return entity;
        }

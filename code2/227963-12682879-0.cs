        /// <summary>
        /// Reseeds a table's identity auto increment to a specified value
        /// </summary>
        /// <typeparam name="TEntity">The row type</typeparam>
        /// <typeparam name="TIdentity">The type of the identity column</typeparam>
        /// <param name="table">The table to reseed</param>
        /// <param name="seed">The new seed value</param>
        public static void ReseedIdentity<TEntity, TIdentity>(this Table<TEntity> table, TIdentity seed)
            where TEntity : class
        {
            var rowType = table.GetType().GetGenericArguments()[0];
            var sqlCommand = string.Format(
                "dbcc checkident ('{0}', reseed, {1})",
                table.Context.Mapping.GetTable(rowType).TableName, 
                seed);
            table.Context.ExecuteCommand(sqlCommand);
        }

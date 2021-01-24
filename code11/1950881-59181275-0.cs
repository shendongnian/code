        public bool Import(IEnumerable<SqlDataRecord> entities, string storedProcedureName)
        {
            var paramDate = new SqlParameter("@StartDate", SqlDbType.DateTime)
            {
                Value = DateTime.Now
            }; 
            
            var paramTable = new SqlParameter("@Wards", SqlDbType.Structured)
            {
                TypeName = "CodeTable",
                Value = entities.ToList()
            };
            var returnValue = _dbContext.Database.ExecuteSqlCommand($"{storedProcedureName} @StartDate, @Wards", paramDate, paramTable);
            return true;
        }

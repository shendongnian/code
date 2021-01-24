        /// <summary>
        /// Filter ScbDataInfo with de field and value indicated
        /// </summary>
        /// <param name="filterParam">Field name</param>
        /// <param name="searchParam">Value used in filter</param>
        /// <returns></returns>
        public IEnumerable<ScbDataInfo> GetScbOptionsByFilter(string filterParam, string searchParam)
        {
            // Here get property using reflection 
            var typeScbDataInfo = typeof(ScbDataInfo);
            var property = typeScbDataInfo.GetProperty(filterParam);
            //var filterExpression =
            using (var context = new SRSContext())
            {
                var query = context.ScbDataInfo
                    .ToArray() // It force linq to sql to obtain all records from database. A poor implementation
                    .Where(
                        m => property.GetValue(m) // Get entity with reflection
                                .ToString() // Convert to string because searchParam is string. It could be changed for the correct type or using dynamic type
                                .Equals(searchParam) // Simple equals for filter
                    );
                return query.ToArray(); // Return array. Poor implementation
            }
        }

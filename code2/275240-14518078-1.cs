            /// <summary>
        /// Returns a new conContractorEntity instance filled with the DataReader's current record data
        /// </summary>
        protected virtual conContractorEntity GetContractorFromReader(IDataReader reader)
        {
            return new conContractorEntity()
            {
                ConId = reader["conId"].ToString().Length > 0 ? int.Parse(reader["conId"].ToString()) : 0,
                ConEmail = reader["conEmail"].ToString(),
                ConCopyAdr = reader["conCopyAdr"].ToString().Length > 0 ? bool.Parse(reader["conCopyAdr"].ToString()) : true,
                ConCreateTime = reader["conCreateTime"].ToString().Length > 0 ? DateTime.Parse(reader["conCreateTime"].ToString()) : DateTime.MinValue
            };
        }

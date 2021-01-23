	public static PersonExtensions
	{
		public static IEnumerable<TType> Search<TType>(this TType row) : where TType : new(), Person 
		{
			DbDataReader reader = Database.Instance.ExecuteReader(sql);
			while(reader.Read()) {
				row.Load(reader);
				yeild return row;
			}
		}
	}

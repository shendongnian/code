    public static string GetStringSafe(this IDataReader reader, int colIndex)
		{
			return GetStringSafe(reader, colIndex, string.Empty);
		}
		public static string GetStringSafe(this IDataReader reader, int colIndex, string defaultValue)
		{
			if (!reader.IsDBNull(colIndex))
				return reader.GetString(colIndex);
			else
				return defaultValue;
		}
		public static string GetStringSafe(this IDataReader reader, string indexName)
		{
			return GetStringSafe(reader, reader.GetOrdinal(indexName));
		}
		public static string GetStringSafe(this IDataReader reader, string indexName, string defaultValue)
		{
			return GetStringSafe(reader, reader.GetOrdinal(indexName), defaultValue);
		}

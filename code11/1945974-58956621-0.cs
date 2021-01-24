    public IDictionary<string, int> GetColumnNames(ref SqlDataReader reader) {
		IDictionary<string, int> dict = new Dictionary<string, int>();
		if (reader == null)
			return dict;
		int columns = reader.FieldCount;
		for (int i = 0; i < columns; i++) {
			dict[reader.GetName(i)] = i;
		}
		return dict;
	}
   

	internal struct Sorter // has to be a struct, because later we are comparing values, not object references
	{
		internal readonly string ColumnName;
		internal bool IsAscending;
	
		internal Sorter(string columnName, bool isAscending)
		{
			this.ColumnName = columnName;
			this.IsAscending = isAscending;
		}
	
		public override string ToString()
		{
			return this.ColumnName + (this.IsAscending ? " ASC" : " DESC");
		}
	}

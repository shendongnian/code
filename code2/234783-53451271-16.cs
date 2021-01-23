	internal class Sorter 
	{
		internal readonly string ColumnName;
		internal bool IsAscending;
	
		internal Sorter(string columnName, bool isAscending)
		{
			this.ColumnName = columnName;
			this.IsAscending = isAscending;
		}
	
		public override bool Equals(object other)
		{  // For equivalence, compare column name only (not object ref or sort order)
			if (other == null) { return false; }
			if (other.GetType() != typeof(Sorter)) { return false; }
			return this.ColumnName == ((Sorter)other).ColumnName;
		}
	
		public override int GetHashCode()
		{ // required if we have overridden Equals
			return this.ColumnName.GetHashCode();
		}
	
		public override string ToString()
		{
			return this.ColumnName + (this.IsAscending ? " ASC" : " DESC");
		}
	}

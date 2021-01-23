	internal class Sorter
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

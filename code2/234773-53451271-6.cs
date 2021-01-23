	internal class Sorters
	{
		private Sorter[] _sorters;
		public Sorters(System.Data.DataColumnCollection columns)
		{
			// I am choosing to start by sort columns in table order, all ascending.
			// You may want to do otherwise.
			this._sorters = new Sorter[columns.Count];
			for (int n = 0; n < columns.Count; n++)
			{
				this._sorters[n] = new Sorter(columns[n].ColumnName, true);
			}
		}
		internal void BringColumnToFrontOfSortingOrder(string sortColumnName, bool isAscending)
		{
			// Move everything down by one that is to the left of the incoming sorter.
			bool foundIt = false;
			for (int n = this._sorters.Length - 1; n > 0; n--)
			{
				if (this._sorters[n].ColumnName == sortColumnName) 
				{
					foundIt = true;
				}
				if (foundIt)
				{
					this._sorters[n] = this._sorters[n - 1]; // move down by one
				}
			}
			// and put our new one at the front
			this._sorters[0] = new Sorter(sortColumnName, isAscending); 
		}
		// Returns a DataView sorting string like "ColName1 ASC, ColName2 DESC" etc
		public override string ToString()
		{
			var s = new System.Text.StringBuilder();
			foreach (Sorter sorter in this._sorters)
			{
				if (s.Length > 0)
				{
					s.Append(", ");
				}
				s.Append(sorter.ToString());
			}
			return s.ToString();
		}
	}

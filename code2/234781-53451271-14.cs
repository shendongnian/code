	using System.Collections.Generic;
	using System.Linq;
	
	internal class Sorters : List<Sorter>
	{
		internal void BringColumnToFrontOfSortingOrder(Sorter sorter)
		{
			if (this.Contains<Sorter>(sorter))
			{
				this.Remove(sorter); // remove it from where it is
			}
			// put it at the start
			this.Insert(0, sorter);
		}
	
		// Returns a DataView sorting string like "ColName1 ASC, ColName2 DESC" etc
		public override string ToString()
		{
			var s = new System.Text.StringBuilder();
			foreach (Sorter sorter in this)
			{
				if (s.Length > 0) { s.Append(", "); }
				s.Append(sorter.ToString());
			}
			return s.ToString();
		}
	}

	using System.Data;
	using System.Windows.Forms;
	using System.ComponentModel;
	
	public class MultiSortingDataGridView : DataGridView // derive from DataGridView and extend it
	{
		private Sorters _sorters = new Sorters(); // keeping track of what column(s) we have searched by
	
		// override the regular search with our super duper multi-column search
		public override void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
		{
			Sorter sorter = new Sorter(dataGridViewColumn.Name, direction == ListSortDirection.Ascending);
			this._sorters.BringColumnToFrontOfSortingOrder(sorter);
	
			// Get the data view that is our data source
			DataView vw = (DataView)this.DataSource;
	
			// When you set the Sort property, it causes it to sort, and happily it sets
			// the up/down glyph of the column that corresponds to your first sort-by item.
			vw.Sort = this._sorters.ToString();
		}
	}

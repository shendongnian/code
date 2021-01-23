	public partial class frmDgvSorting : Form
	{
		private DataView _dvw;
		private Sorters _sorters;
		public frmDgvSorting()
		{
			InitializeComponent();
			DataTable tbl = GetTestData();
			this._sorters = new Sorters(tbl.Columns); // Make a sorter from my table
			this._dvw = new DataView(tbl); // Make a data view from my data table
			// Do the initial sort of my data view - assigning a value to Sort triggers an immediate sort
			this._dvw.Sort = this._sorters.ToString();
			// Bind my DataGridView to my DataView as a source.
			this.dgv.DataSource = this._dvw; // assume .dgv is the name of my DataGridView.
		}
	}

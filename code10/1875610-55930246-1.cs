	<DataGrid ItemsSource="{Binding MyTable}" />
    ...
	public class MainViewModel : ViewModelBase
	{
		public DataTable MyTable { get; } = new DataTable();
		private int NumColumns = 3;
		public MainViewModel()
		{
			this.MyTable = new DataTable();
			this.MyTable.Columns.Add("Name");
			this.MyTable.Columns.Add("Type");
			for (int i = 1; i <= NumColumns; i++)
				this.MyTable.Columns.Add($"Day {i}");
			var row = this.MyTable.NewRow();
			row.ItemArray = new object[] { "Tom", "Type A", "1.2", "2.3", "3.4" };
			this.MyTable.Rows.Add(row);
			row = this.MyTable.NewRow();
			row.ItemArray = new object[] { "Dick", "Type B", "2.3", "3.4", "4.5" };
			this.MyTable.Rows.Add(row);
			row = this.MyTable.NewRow();
			row.ItemArray = new object[] { "Harry", "Type C", "3.4", "4.5", "5.6" };
			this.MyTable.Rows.Add(row);
		}
	}

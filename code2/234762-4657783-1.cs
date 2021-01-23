    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
      public partial class Form1 : Form
      {
         DataSet1 dataset;
         public Form1()
         {
            InitializeComponent();
            dataset = new DataSet1(); // three columns: Priority(Int32), Date (DateTime) and Description(String)
            dataset.DataTable1.AddDataTable1Row(1, DateTime.Parse("01-jan-10"), "this");
            dataset.DataTable1.AddDataTable1Row(1, DateTime.Parse("02-jan-10"), "is");
            dataset.DataTable1.AddDataTable1Row(1, DateTime.Parse("03-jan-10"), "a");
            dataset.DataTable1.AddDataTable1Row(2, DateTime.Parse("04-jan-10"), "sample");
            dataset.DataTable1.AddDataTable1Row(2, DateTime.Parse("05-jan-10"), "of");
            dataset.DataTable1.AddDataTable1Row(2, DateTime.Parse("06-jan-10"), "the");
            dataset.DataTable1.AddDataTable1Row(3, DateTime.Parse("07-jan-10"), "data");
            dataset.DataTable1.AddDataTable1Row(3, DateTime.Parse("08-jan-10"), "in");
            dataset.DataTable1.AddDataTable1Row(3, DateTime.Parse("09-jan-10"), "use");
            dataGridView1.DataSource = dataset.DataTable1.DefaultView;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[0].HeaderCell = new MyDataGridViewColumnHeaderCell();
            dataGridView1.Columns[1].HeaderCell = new MyDataGridViewColumnHeaderCell();
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;
         }
         private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
         {
            DataGridViewColumn clickedColumn = dataGridView1.Columns[e.ColumnIndex];
            if (clickedColumn.HeaderCell is MyDataGridViewColumnHeaderCell)
            {
               DoMultiColumnSort();
            }
            else
            {
               dataGridView1.Columns.OfType<DataGridViewColumn>()
                                    .Where(column => column.HeaderCell is MyDataGridViewColumnHeaderCell)
                                    .ForEach(column => ((MyDataGridViewColumnHeaderCell)column.HeaderCell).SortOrderDirection = SortOrder.None);
            }
            this.textBox1.Text = dataset.DataTable1.DefaultView.Sort;
         }
         private void DoMultiColumnSort()
         {
            var sortClauses = dataGridView1.Columns.OfType<DataGridViewColumn>()
                                                   .Where(column => column.HeaderCell is MyDataGridViewColumnHeaderCell)
                                                   .Select(column => GetSortClause(column));
            dataset.DataTable1.DefaultView.Sort = String.Join(",", sortClauses);
         }
         private String GetSortClause(DataGridViewColumn column)
         {
            SortOrder direction = column.HeaderCell.SortGlyphDirection;
            if (column.HeaderCell is MyDataGridViewColumnHeaderCell)
            {
               direction = ((MyDataGridViewColumnHeaderCell)column.HeaderCell).SortOrderDirection;
            }
            return column.DataPropertyName + " " + (direction == SortOrder.Descending ? "DESC" : "ASC");
         }
      }
      public partial class MyDataGridViewColumnHeaderCell : DataGridViewColumnHeaderCell
      {
         public SortOrder SortOrderDirection { get; set; } // defaults to zero = SortOrder.None;
         protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
         {
            this.SortGlyphDirection = this.SortOrderDirection;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
         }
         public override object Clone()
         {
            MyDataGridViewColumnHeaderCell result = (MyDataGridViewColumnHeaderCell)base.Clone();
            result.SortOrderDirection = this.SortOrderDirection;
            return result;
         }
         protected override void OnClick(DataGridViewCellEventArgs e)
         {
            this.SortOrderDirection = (this.SortOrderDirection != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending;
            base.OnClick(e);
         }
      }
      public static partial class Extensions
      {
         public static void ForEach<T>(this IEnumerable<T> value, Action<T> action) { foreach (T item in value) { action(item); } }
      }
    }

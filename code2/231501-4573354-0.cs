    public partial class LinqGrid<T> : UserControl where T : class, new()
    {
            System.Data.Linq.Table<T> tmpDataTable;
            public LinqGrid()
            {
                InitializeComponent();
            }
            public void Bind(System.Data.Linq.Table<T> listSource)
            {          
                Project.dbClassesDataContext dbc = new Project.dbClassesDataContext();
                tmpDataTable = listSource;
                var query = (from c in listSource select c);
                dgvRecords.DataSource = query.Take(10).ToList();
            }
            private void btnNext_Click(object sender, EventArgs e)
            {
                tmpDataTable.Skip(10).Take(10); ....
            }
       }

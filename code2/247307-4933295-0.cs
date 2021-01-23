    public partial class ListViewITemplate : System.Web.UI.Page
    {
        private static IList<string> Columns
        {
            get
            {
                return new List<string>() { "ColumnA", "ColumnB", "ColumnC", "ColumnD", "ColumnE" };
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dataTable = LoadDataSource();
            IEnumerable<string> columns = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            MyListView.LayoutTemplate = new MyLayoutTemplate(columns);
            MyListView.ItemTemplate = new MyItemTemplate(columns);
            MyListView.DataSource = dataTable;
            MyListView.DataBind();
        }
        private static DataTable LoadDataSource()
        {
            DataTable dataTable = new DataTable();
            IEnumerable<string> selectedColumns = Columns.Skip(1);
            foreach (string column in selectedColumns)
            {
                dataTable.Columns.Add(column, typeof(string));
            }
            for (int i = 0; i < 100; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (string column in selectedColumns)
                {
                    dataRow[column] = "Data in " + column + " " + i;
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
    }
    public class MyLayoutTemplate : ITemplate
    {
        private IEnumerable<string> Columns { get; set; }
        public MyLayoutTemplate(IEnumerable<string> columns)
        {
            Columns = columns;
        }
        public void InstantiateIn(Control container)
        {
            HtmlGenericControl MyHtmlTable = new HtmlGenericControl("table");
            HtmlGenericControl MyHtmlTableHead = new HtmlGenericControl("thead");
            HtmlGenericControl MyHtmlTableRow = new HtmlGenericControl("tr");
            foreach (string column in Columns)
            {
                HtmlGenericControl MyHtmlTableCell = new HtmlGenericControl("th");
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton.ID = "lbn" + column;
                MyLinkButton.Text = column;
                MyLinkButton.ToolTip = "Sort by " + column;
                MyLinkButton.CommandArgument = column;
                MyLinkButton.Command += new CommandEventHandler(MyLinkButton_Command);
                MyHtmlTableCell.Controls.Add(MyLinkButton);
                MyHtmlTableRow.Controls.Add(MyHtmlTableCell);
            }
            MyHtmlTableHead.Controls.Add(MyHtmlTableRow);
            MyHtmlTable.Controls.Add(MyHtmlTableHead);
            HtmlGenericControl MyHtmlTableBody = new HtmlGenericControl("tbody");
            HtmlGenericControl MyHtmlItemPlaceholderRow = new HtmlGenericControl("tr");
            MyHtmlItemPlaceholderRow.ID = "itemPlaceholder";
            MyHtmlTableBody.Controls.Add(MyHtmlItemPlaceholderRow);
            MyHtmlTable.Controls.Add(MyHtmlTableBody);
            container.Controls.Add(MyHtmlTable);
        }
        protected void MyLinkButton_Command(object sender, CommandEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    public class MyItemTemplate : ITemplate
    {
        private IEnumerable<string> Columns { get; set; }
        public MyItemTemplate(IEnumerable<string> columns)
        {
            Columns = columns;
        }
        public void InstantiateIn(Control container)
        {
            HtmlGenericControl MyHtmlTableRow = new HtmlGenericControl("tr");
            MyHtmlTableRow.DataBinding += new EventHandler(MyTableRow_DataBinding);
            container.Controls.Add(MyHtmlTableRow);
        }
        protected void MyTableRow_DataBinding(object sender, EventArgs e)
        {
            HtmlGenericControl MyHtmlTableRow = (HtmlGenericControl)sender;
            DataRowView dataRowView = ((ListViewDataItem)MyHtmlTableRow.NamingContainer).DataItem as DataRowView;
            foreach (string column in Columns)
            {
                HtmlGenericControl MyHtmlTableCell = new HtmlGenericControl("td");
                MyHtmlTableCell.ID = "MyHtmlTableCell" + column;
                Literal MyLiteral = new Literal();
                MyLiteral.ID = "Data" + column;
                MyLiteral.Text = dataRowView[column].ToString();
                MyHtmlTableCell.Controls.Add(MyLiteral);
                MyHtmlTableRow.Controls.Add(MyHtmlTableCell);
            }
        }
    }

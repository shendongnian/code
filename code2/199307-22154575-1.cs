    <%@ Page Language="C#" %>
    <%@ Import Namespace="System.Data" %>
    <%@ Import Namespace="System.Drawing" %>
    <html>
    <head runat="server">
        <script runat="server">
            protected void Page_Load(object sender, EventArgs eventArgs)
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Notes", typeof(string));
                data.Columns.Add("RequestedDate", typeof(DateTime));
                for (int idx = 0; idx < 5; idx++)
                {
                    DataRow row = data.NewRow();
                    row["Id"] = idx;
                    row["Notes"] = string.Format("Note {0}", idx);
                    row["RequestedDate"] = DateTime.Now.Subtract(new TimeSpan(idx, 0, 0, 0, 0));
                    data.Rows.Add(row);
                }
                listData.DataSource = data;
                listData.DataBind();
            }
    
            private void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                foreach (TableCell tableCell in e.Row.Cells)
                {
                    DataControlFieldCell cell = (DataControlFieldCell)tableCell;
                    if (cell.ContainingField.HeaderText == "Id")
                    {
                        cell.Visible = false;
                        continue;
                    }
                    if (cell.ContainingField.HeaderText == "Notes")
                    {
                        cell.Width = 400;
                        cell.BackColor = Color.Blue;
                        continue;
                    }
                    if (cell.ContainingField.HeaderText == "RequestedDate")
                    {
                        cell.Width = 130;
                        continue;
                    }
                }
            }
    
        </script>
    </head>
    <body>
        <form runat="server">
            <asp:GridView runat="server" ID="listData" AutoGenerateColumns="True" HorizontalAlign="Left"
                PageSize="20" OnRowDataBound="GridView_RowDataBound" EmptyDataText="No Data Available."
                Width="95%">
            </asp:GridView>
        </form>
    </body>
    </html>

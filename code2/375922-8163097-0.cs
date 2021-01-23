    public partial class DynamicCombo : System.Web.UI.Page
        {
            DropDownList list;
    
            protected void Page_Init(object sender, EventArgs e)
            {
                Table table = CreateHtmlTable();
                list = new DropDownList();
                list.AutoPostBack = true;
                list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
                list.ID = "cbo";
                list.Items.Add(new ListItem("value1", "1"));
                list.Items.Add(new ListItem("value2", "2"));
                list.Items.Add(new ListItem("value3", "3"));
                table.Rows[0].Cells[0].Controls.Add(list);
    
                pnl.Controls.Add(table);
            }
    
            private void list_SelectedIndexChanged(object sender, EventArgs e)
            {
                Response.Write("<script>alert(\"" + list.SelectedIndex + "\");</script>");
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            private Table CreateHtmlTable()
            {
                Table table = new Table();
                table.Rows.Add(new TableRow());
                table.Rows[0].Cells.AddRange(new TableCell[] { new TableCell(),
                                                           new TableCell(),
                                                           new TableCell()});
                return table;
            }
        }

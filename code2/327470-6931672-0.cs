        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] dynamicTable = { "First Name", "Last Name", "Address", "Phone" };
                foreach (string s in dynamicTable)
                {
                    TableRow row = new TableRow();
                    // Add First Cell with Text to Row
                    row.Cells.Add(new TableCell() { Text = s });
                    // Create Second Cell
                    TableCell textBoxCell = new TableCell();
                    // Add Textbox Control to Second Cell
                    textBoxCell.Controls.Add(new TextBox() { ID = "Dynamic_" + s.Replace(" ","_") });
                    // Add Second Cell to Row
                    row.Cells.Add(textBoxCell);
                    // Add New Row to Table
                    editDataTable.Rows.Add(row);
                }
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Request.Form.Count; i++)
            {
                string key = Request.Form.GetKey(i);
                if (key.Contains("Dynamic_"))
                {
                    Response.Write("<p><strong>" + (key.Remove(0,8)).Replace("_"," ") + "</strong>&nbsp;&nbsp;::&nbsp;&nbsp;" + Request.Form[i] + "</p>");
                }
            }
        }

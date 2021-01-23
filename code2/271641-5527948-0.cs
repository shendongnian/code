    <div>
        <asp:Table runat="server" ID="myTable" />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="B1_Click" />
    </div>
    //add a new control to the table.
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox t1 = new TextBox();
        t1.ID = "t1";
        t1.Text = t1.ID;
        AddToTable(t1);
    }
    
    public void AddToTable(TextBox t)
    {
        TableRow tr = new TableRow();
        tr.Cells.Add(new TableCell());
        tr.Cells[0].Controls.Add(t);
        myTable.Rows.Add(tr);
    }
    
    protected void B1_Click(object sender, EventArgs e)
    {
        Control t = Page.FindControl("t1");
    
        if (t != null)
        {
            string id = t.ID;
        }
    }
    

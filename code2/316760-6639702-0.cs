    protected void AddRow_Click(object sender, EventArgs e)
    {
       CreateTableWithSession()
       ...................
    }
    protected void GetValue_Click(object sender, EventArgs e)
    {
       CreateTableWithSession()
       TextBox txtBoxUserName = this.FindControl("RowNo1ColumnNo1") as TextBox;
       ........................
    }

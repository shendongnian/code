    protected void Page_Load(object sender, EventArgs e)
    {
         autocomplete();
    }
    protected void autocomplete()
    {
        Database p = new Database();
        DataSet ds = new DataSet();
        ds = p.sqlcall("select [name] from [stu_reg]");
        int row = ds.Tables[0].Rows.Count;
        string abc="";
        for (int i = 0; i < row;i++ )
            abc = abc + "<option>"+ds.Tables[0].Rows[i][0].ToString()+"</option>";
        datalist1.InnerHtml = abc;
    }

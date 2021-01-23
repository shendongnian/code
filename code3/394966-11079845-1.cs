    protected void Page_Load(object sender, EventArgs e)
    {
        string id = GenerateId("TblTransactions", "TId", 8, "TRN");
	// insert the id along with data in the table
        Response.Write(id);
    }
    public string GenerateId(string TableName, string ColumnName, int ColumnLength, string Prefix)
    {
        SqlConnection con = new SqlConnection("server=.;integrated security=true;database=EBissCard");
        string Query, Id;
        int PrefixLength, PadLength;
        PrefixLength = Convert.ToInt32(Prefix.Length);
        PadLength = ColumnLength - PrefixLength;
        Query = "SELECT '" + Prefix + "' + REPLACE(STR(MAX(CAST(SUBSTRING(" + ColumnName + "," + Convert.ToString(PrefixLength + 1) + "," + PadLength + ") AS INTEGER))+1," + PadLength + "),' ',0) FROM " + TableName;
        SqlCommand com = new SqlCommand(Query, con);
        con.Open();
        if (com.ExecuteScalar().ToString() == "")
        {
            Id = Prefix;
            for (int i = 1; i <= PadLength - 1; i++)
            {
                Id += "0";
            }
            Id += "1";
        }
        else
        {
            Id = Convert.ToString(com.ExecuteScalar());
        }
        con.Close();
        return Id;
    }

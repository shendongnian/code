    public DataTable FillGrid()
    {
        String q = "Select * from customer_info";
        DbCon con = new DbCon();
        return con.GetGridData(q);
    }

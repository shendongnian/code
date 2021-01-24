    public string Phonecheck(ref string phone)
    {
        bool success = false;
        DataTable dt = new DataTable();
        string strSql = "SELECT phone_partno ";
        strSql += "from phoneconvertcode  ";
        strSql += "WHERE phone_partno = substr('" + phone + "', 1, 15) ";
        cls.GetDataTable(strSql, out dt);
        if (dt.Rows.Count == 1)
        {
            success = true;
            phone = dt.Rows[0][0];  // assign "converted" value to phone ref parameter
        }
        return success;
    }

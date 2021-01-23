    if (!IsPostBack && DayBox.Text == "" && MonthBox.Text != "" && YearBox.Text != "")
    {
        IPDropDownList.Items.Clear();
        string date = String.Format("{0}/{1}",MonthBox.Text, YearBox.Text);
        sqlStatment = String.Format("SELECT IPAddress FROM IPActivity WHERE AccessDate LIKE '%{0}' GROUP BY IPAddress;", date);
        MyDataSet = RetriveDataBase(connection, sqlStatment, tableName);
        foreach (DataRow dr in MyDataSet.Tables[tableName].Rows;)
        {
            IPDropDownList.Items.Add(dr[0].ToString());
        }   
    }

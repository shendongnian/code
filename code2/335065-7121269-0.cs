    if (!IsPostBack)
    {
        if (DayBox.Text == "" && MonthBox.Text != "" && YearBox.Text != "")
        {
            IPDropDownList.Items.Clear();
            string date;
            date = String.Format("{0}/{1}",MonthBox.Text, YearBox.Text);
            sqlStatment = String.Format("SELECT IPAddress FROM IPActivity WHERE AccessDate LIKE '%{0}' GROUP BY IPAddress;", date);
            MyDataSet = RetriveDataBase(connection, sqlStatment, tableName);//method written by me
            dra = MyDataSet.Tables[tableName].Rows;
            foreach (DataRow dr in dra)
            {
                IPDropDownList.Items.Add(dr[0].ToString());
            }   
        }
    }

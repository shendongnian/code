    DataTable dt = GetTable();
    for(int i = 0; i< dt.Rows.Count;i++)
        for (int j = 0; j <dt.Columns.Count ; j++)
        {
             object o = dt.Rows[i].ItemArray[j];
             //if you want to get the string
             //string s = o = dt.Rows[i].ItemArray[j].ToString();
        }

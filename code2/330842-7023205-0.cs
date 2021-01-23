    for (int i = 0; i < dsExcel.Tables[0].Rows.Count; i++)
    {
        string ID = ds.Tables[0].Rows[i][0].ToString();
        Int16 CustID = Convert.ToInt16(ID);
        string CustName = dsExcel.Tables[0].Rows[i][1].ToString();
        string CardScheme = dsExcel.Tables[0].Rows[i][2].ToString();
        string Outlet = dsExcel.Tables[0].Rows[i][3].ToString();
        string TerminalNum = dsExcel.Tables[0].Rows[i][4].ToString();
        Int32 Terminal = Convert.ToInt32(TerminalNum);
        string Date1 = dsExcel.Tables[0].Rows[i][5].ToString();
        DateTime Date = Convert.ToDateTime(Date1);
        string Time = dsExcel.Tables[0].Rows[i][6].ToString();
        DateTime DateTime = Convert.ToDateTime(Time);
        string Amount1 = ds.Tables[0].Rows[i][7].ToString();
        double Amount = Convert.ToDouble(Amount1);
    
        /*** Add this if-statement to you code! ***/
        if(string.IsNullOrEmpty(ID + CustName + CardScheme + Outlet + TerminalNum + Date1 + Time + Amount1))
        {
            continue;
        }
    
        SqlCommand com = new SqlCommand("insert into Customer(CustID,CustName,CardScheme,Outlet,TerminalNum,TranDate,TranDateTime,Amount) values ('" + CustID + "','" + CustName + "','" + CardScheme + "','" + Outlet + "','" + Terminal + "','" + Date + "','" + DateTime + "','" + Amount + "')", connection);
        com.ExecuteNonQuery();
    }

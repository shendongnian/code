    StringBuilder updateQuery = new StringBuilder("");
    while (rdr.Read())
    {
       temp = (rdr[harltabcol[i, 0]].ToString()).ToString();
       temp1 = (Iscii2Unicode(temp)).ToString();
       updateQuery.Append("UPDATE [" + harltabcol[i,1] + "] SET [" + harltabcol[i,0] + "] =N'"+temp1+"' WHERE " + harltabcol[i,0] + "='" + temp + "';");
    } 
    SqlCommand cmdUpd = new SqlCommand(updateQuery.ToString(),cn1);
    cn1.Open();
    cmdUpd.CommandTimeout = 0;
    cmdUpd.ExecuteNonQuery();
    temp = null;
    temp1 = null;
    cn1.Close();
    cn.Close(); 

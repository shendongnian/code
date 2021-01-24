        try
        {
            MySqlCommand name = new MySqlCommand("SELECT * from munkaorak WHERE Munkaszam=@m", kapcsolat);
            name.Parameters.AddWithValue("@m", cbMunka.Text);
            if (cbRész.Text != "")
            {
                name.CommandText += " AND Részfolyamat=@r";
                name.Parameters.AddWithValue("@r", cbRész.Text);
            }
            if (cbTech.Text != "")
            {
                name.CommandText += " AND TechKod=@t";
                name.Parameters.AddWithValue("@t", cbTech.Text);
            }
            
            name.CommandText += " order by ID DESC"; //is it really necessary?
            MySqlDataAdapter da = new MySqlDataAdapter(name);
            DataTable dt = new DataTable();
            da.Fill(dt);
   
            foreach(DataRow ro in dt.Rows){
              string fromStr = ro["YOUR_FROM_DATE_COLUMN_NAME"].ToString();
              //cope with dates in varying formats
              //by replacing all non-numeric chars with nothing
              fromStr = Regex.Replace(fromStr, @"[^0-9]", "");
              //now our dates of [2019. 09. 23. 14:54:23], [2019.09.23 14:54:23] or [2019-09-23 14:54:23]
              //just become 20190923145423
              DateTime fromDt = DateTime.ParseExact(fromStr, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
              string toStr = ro["YOUR_TO_DATE_COLUMN_NAME"].ToString();
              toStr = Regex.Replace(toStr, @"[^0-9]", "");
              DateTime toDt = DateTime.ParseExact(toStr, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
              //total hours worked
              (toDt - fromDt).TotalHours;
            }
       }

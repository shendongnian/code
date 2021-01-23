        string dt;   
        string dt2;
        DateTime date = DateTime.Now;    
        DateTime date2 = DateTime.Now;    
        dt = date.ToLongTimeString();        // display format:  11:45:44 AM
        dt2 = date2.ToShortDateString();     // display format:  5/22/2010
        cmd.Parameters.Add("@time_out", SqlDbType.NVarChar,50).Value = dt;
        cmd.Parameters.Add("@date_out", SqlDbType.NVarChar, 50).Value = dt2;
        cmd.Parameters.Add("@date_time", SqlDbType.NVarChar, 50).Value = string.Concat(dt2, " ", dt); // display format:  11/11/2010 4:58:42
 

        con.Open();
        SqlCommand cmd = new SqlCommand("select Processor,HDD,RAM,Display,Graphics,OS,processor,hdd,ram,display,os,opticaldrive,warranty,price,other,graphics,images,Warranty,Price,Images,other from System where CompanyName='"+companyname.Text+"'",con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            processor.Text = dr.GetValue(3).ToString();
        }
        con.Close();
    }

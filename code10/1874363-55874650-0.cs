     List<string> phoneList = new List<string>();
     conn.Open();
     MySqlCommand sda = new MySqlCommand("select * from members where Branch='" + lbladminbranch.Text + "' and Country='" + lbladmincountry.Text + "'", conn);
    
     MySqlDataReader dr = sda.ExecuteReader();
    
     while (dr.Read())
     {
        phoneList.Add("44" + dr["Phone"].ToString());
     }
     txtsmsphoneno.Text = string.Join(",",phoneList);
     conn.Close();

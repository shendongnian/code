        foreach (DataRow dr in dt.Rows)
        {
            found = false;
            foreach (RadListBoxItem item in RadListBox2.Items)
            {
                if (String.Compare(item.Value, dr["DeptID"].ToString()) == 0)
                {
                    found = true;
                }
            }
                if (found == false)
                {
                     //delete here
                }
            }
        
    } 

    if(!strPermission.Equals(null)//or ""
     {
        if (strPermission == "Admin")
        {
            btnActivate.Enabled = true;
        }
        else if (strPermission == "ReadOnly")
        {
            btnActivate.Enabled = false;
        }
     }else{ 
        //value of permision is empty
        MessageBox.Show("Permission is empty");
     }

    string delval = "";
    
    for (int i = 0; i <= NoOfUsers - 1; i++) 
    {
        // your existing stuff
        // ...
        if (string.IsNullOrEmpty(delval)) 
        {
            delval = Loginusername;
        }
        else
        {                     
            delval = delval + "," + Loginusername;                 
        }
    }
    
    if (flag == "Yes") 
    {         	
        // your existing stuff
        // ...
        cmd_mail.Parameters.Add("@deleteusers", SqlDbType.NVarChar).Value = delval;
    }

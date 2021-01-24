    for (int i = 0; i < countStart; i++)    //Create all content of the table in here
    {
        //CREATE ALL LABELS
        var p = new Panel();
        p.ID = "pnl" + ds1.Tables[0].Rows[i]["COLUMN_NAME"].ToString() + i.ToString();
        form1.Controls.Add(p);
    
        ...
    
        p.Controls.Add(lbl);
    
        ...
    
        p.Controls.Add(space);  //SPACE 
    
        ...
    
    
        p.Controls.Add(textbox1);
    }

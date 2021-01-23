    for (int i = 0; i < x; i++)
    {
        CheckBox cb = new CheckBox();
    
        cb.ID = "checkBox" + i;
    
        PlaceHolder1.Controls.Add(cb);
    
        PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
    }

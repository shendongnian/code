    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {         
        LinkButton ln = new LinkButton();
        ln.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        ln.ID =  ds.Tables[0].Rows[i].ItemArray[1].ToString();  
        ln.Click += new EventHandler(Clicked);
        divonlne.Controls.Add(ln);
        divonlne.Controls.Add(new LiteralControl("<br/>"));
    }

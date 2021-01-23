    foreach(var btn in this.Controls)
    {
        Button tmpbtn;
        try
        {
            tmpbtn = (Button) btn;
        }
        catch(InvalidCastException e)
        {
            //perform required exception handelling if any.
        }
        if(tmpbtn != null)
        {
           if(string.Compare(tmpbtn.Name,0,"btn_",0,4) == 0)
           {
                tmpbtn.Text = "Somthing"; //Place your text here
           }
        }
    }

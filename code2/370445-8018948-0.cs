    public double getUnitStake(Form frontpage)
    {
    
        double doubleresult=0;
       
    
        foreach (Control c in frontpage.Controls)
        {
            if (c.Name == "tbUnitStake")
            {
    
                double.TryParse( (c as TextBox).Text, out doubleresult);
            }
        }
    
    
        return doubleresult;
    }

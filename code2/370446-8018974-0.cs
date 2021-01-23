     public double getUnitStake(Form frontpage)
    {
        double doubleresult=0;
        bool unitStake;
        foreach (Control c in frontpage.Controls)
        {
            if (c.Name == "tbUnitStake")
            {
                unitStake = double.TryParse( (c as TextBox).Text, out doubleresult);
            }
        }
        return doubleresult;
    }

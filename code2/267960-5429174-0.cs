    float rate;
    
    if(ddl_Code.SelectedValue ==  "A")
    {
       rate = .25F;
    }
    else if(ddl_Code.SelectedValue ==  "B" && Convert.ToDecimal(tb_Salary.Text) <= 45000)
    {
       rate = .3F;
    }
    else
    {
       rate = .33F;
    }
    
    tb_TaxDue.Text = Convert.ToDecimal(tb_Salary.Text) * rate;

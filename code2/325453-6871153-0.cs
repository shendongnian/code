    public DataTable CostOfKilowat()
    {
        DataTable CostDT = new DataTable();
        try
        {
            int Dollar = Convert.ToInt32(txtCommission.Text);
            CostDT = GetProducts();
            DataTable Costtable = GetCostRate(CostDT, Dollar, "DATE,MTU,POWER,COST,VOLTAGE,PERUNITCOST", "DATE", "Group by ");
            return Costtable;
        }
        catch 
        {
            String script = "<script>alert('Enter Valid Cost')</script>";
            Page.RegisterStartupScript("script", script);
        }
        return CostDT;
    }

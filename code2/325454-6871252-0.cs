    public DataTable CostOfKilowat()
        {
            DataTable Costtable = null;
            try
            {
                int Dollar = Convert.ToInt32(txtCommission.Text);
                DataTable CostDT = GetProducts();
                Costtable = GetCostRate(CostDT, Dollar, "DATE,MTU,POWER,COST,VOLTAGE,PERUNITCOST", "DATE", "Group by ");
            }
            catch 
            {
                String script = "<script>alert('Enter Valid Cost')</script>";
                Page.RegisterStartupScript("script", script);
            }
            return Costtable;
        }

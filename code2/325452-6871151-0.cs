      public DataTable CostOfKilowat()
            {
                try
                {
                    DataTable CostDT = new DataTable();
                    int Dollar = Convert.ToInt32(txtCommission.Text);
                    CostDT = GetProducts();
                    DataTable Costtable = GetCostRate(CostDT, Dollar, "DATE,MTU,POWER,COST,VOLTAGE,PERUNITCOST", "DATE", "Group by ");
                    return Costtable;
                }
                catch(Exception ex)
                {
                    String script = "<script>alert('" + ex.Message + "')</script>";
                    Page.RegisterStartupScript("script", script);
                    return null;
                }
            }

     public FixPayrollMonth(string pay)
     {
          StoreProcPayrollMonth("fix_Payroll_PayingMonth", pay);
    }
    private FixPayrollMonth StoreProcPayrollMonth(string storeprocedurename, string pay)
    {
        FixPayrollMonth result = new FixPayrollMonth() {IsSuccess = false };
        SqlCommand cmd = new SqlCommand(storeprocedurename, Connection);
        cmd.Parameters.Add(new SqlParameter("@Month_Change", pay ));         
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Connection.Open();
        using (var data = cmd.ExecuteReader())
        {
            while (data.Read())
            {
                result.MonthChanged = Convert.ToInt32(data["MonthChanged"]);
                result.IsSuccess = Convert.ToBoolean(data["IsSuccess"]);
            }
        }
        return result;
    }

    private async Task<decimal?> DoItAsync(yourType dates)
    {
        return await Task.Run(()=> 
        {
            using (DataSet result = calculationMgr.EvaluateFormula(companyID, dates.startDate, dates.endDate, subIndicatorID.Value.ToString(), null, false, null
            , (int)Common.Systems.Sustainability.Constants.ApprovalStatuses.Approved
            ))
        {
            DataRow dr = result.Tables[0].Rows[0];
            //totalPrice = Convert.ToDecimal(dr["Result"]).ToString("#,##0.00");
            return Common.Util.TryToConvertToDecimal(dr, "Result");        
        }
       });
    }

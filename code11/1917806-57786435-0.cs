    var listTotalCost = listDates
    .AsParallel() // this makes it parallel
    .WithDegreeOfParallelism(2) // optional
    .Select(date =>
    {
        using (DataSet result = calculationMgr.EvaluateFormula(companyID,
            date.startDate, date.endDate, subIndicatorID.Value.ToString(),
            null, false, null,
            (int)Common.Systems.Sustainability.Constants.ApprovalStatuses.Approved))
        {
            DataRow dr = result.Tables[0].Rows[0];
            return Common.Util.TryToConvertToDecimal(dr, "Result");
        }
    })
    .Where(v => v != null)
    .Select(v => v.Value)
    .ToList();

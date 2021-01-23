	protected void FillTradeSetups()
	{
		DBUtil DB = new DBUtil();
		FillDdl(ddlSetups, "tradeSetupId", DB.GetTradeSetups);
	}
	protected void FillTimeFrames()
	{
		DBUtil DB = new DBUtil();
		FillDdl(ddlTimeFrames, "tfCode", DB.GetTimeFrames);
	} 
	protected void FillTradeGrades()
	{
		DBUtil DB = new DBUtil();
		FillDdl(ddlTradeGrades, "tradeGrade", "descr", DB.GetTradeGrades);
	}
	protected void FillExecutionGrades()
	{
		DBUtil DB = new DBUtil();
		FillDdl(ddlExecutionGrades, "executionGrade", "descr", DB.GetExecutionGrades);
	} 

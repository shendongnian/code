	private void LoadCategoryTest(Int32 CategoryID)
	{
		string cmdText = "SELECT ProductID, ProductName, CompanyName, Details, PurchasingCode FROM Products WHERE CategoryID = " + CategoryID + "; ";
		DataSet ds;
		DataTable dt;
		ds = DatabaseAccess.GetQueryResults(cmdText);
		if (ds.Tables.Count > 0)
		{
			dt = ds.Tables(0);
			this.dgBends.DataSource = dt;
		}
	}
		

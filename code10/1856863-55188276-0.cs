	public void CreateTableDefsUsingInterop(string accessFilePath, string accessTable, string oracleUser, string oraclePassword, string oracleTable, string oracleDSNFilePath)
	{
		var strConn = $"ODBC;FILEDSN={oracleDSNFilePath};UID={oracleUser};PWD={oraclePassword}";
		var sTypExprt = "ODBC Database";
		var interop = new Application();
		interop.OpenCurrentDatabase(accessFilePath);
		var db = interop.CurrentDb();
		var emptyTable = $"n{accessTable}";
		QueryDef qd;
		qd = db.CreateQueryDef("access2ora1", $"select top 1 * into [{emptyTable}] from [{accessTable}]");
		qd.Execute();
		qd = db.CreateQueryDef("access2ora2", $"delete from [{emptyTable}]");
		qd.Execute();
		interop.DoCmd.TransferDatabase(AcDataTransferType.acExport, sTypExprt, strConn, AcObjectType.acTable, emptyTable, oracleTable);
		interop.Quit(AcQuitOption.acQuitSaveNone);
	}

    var pCustNbr = new OleDbParameter("P_CUSTNBR", OleDbType.Decimal) { Value = customerNbr }; 
    var pPremNbr = new OleDbParameter("P_PREM_NBR", OleDbType.Decimal) { Value = premiseNbr };
    var pCmsgType = new OleDbParameter("P_CMSG_TYPE", OleDbType.Decimal) { Value = cmsgType };
    var pCmsgText = new OleDbParameter("P_CMSG_TEXT", OleDbType.VarChar) { Value = cmsgText };
    var pStatus = new OleDbParameter("O_STATUS", OleDbType.Integer, 10, System.Data.ParameterDirection.Output, true, 0, 0, null, System.Data.DataRowVersion.Current, null);
    var pSqlCode = new OleDbParameter("O_SQLCODE", OleDbType.Integer, 10, System.Data.ParameterDirection.Output, true, 0, 0, null, System.Data.DataRowVersion.Current, null);

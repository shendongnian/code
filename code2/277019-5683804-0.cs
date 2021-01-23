    private void ShowStatements(string agreementId)
        {
            //var crvStatements = new CrystalReportViewer(); //created on the page
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Server.MapPath("Statements.rpt"));
            crvStatements.ReportSource = reportDocument;
            System.Data.DataTable dt1 = new dsStatements.usp_GetBillDetailsByAgreementIdDataTable();
            System.Data.DataTable dt2 = new dsStatements.usp_GetTransactionTypesByAgreementIdForBillDataTable();
            System.Data.DataSet statements = new System.Data.DataSet();
            statements.Tables.Add(dt1);
            statements.Tables.Add(dt2);
            reportDocument.SetDataSource(dsStatements);
            crvStatements.DataBind();
        }

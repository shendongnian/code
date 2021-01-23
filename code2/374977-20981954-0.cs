        private static List<string> GetCommandText(CrystalDecisions.CrystalReports.Engine.ReportDocument report)
        {
            var rptClientDoc = report.ReportClientDocument;
            return rptClientDoc.DatabaseController.Database.Tables.OfType<CommandTable>()
                  .Select(cmdTbl => cmdTbl.CommandText).ToList();
        }

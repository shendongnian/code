      class Program
    {
        static void Main(string[] args)
        {
            var entities = new NewBusinessEntities();
            
            var dt = new DataTable();
            dt.Columns.Add("WarningCode");
            dt.Columns.Add("StatusID");
            dt.Columns.Add("DecisionID");
            dt.Columns.Add("Criticality");
            dt.Rows.Add("EO01", 9, 4, 0);
            dt.Rows.Add("EO00", 9, 4, 0);
            dt.Rows.Add("EO02", 9, 4, 0);
            var caseId = new SqlParameter("caseid", SqlDbType.Int);
            caseId.Value = 1;
            var userId = new SqlParameter("userid", SqlDbType.UniqueIdentifier);
            userId.Value = Guid.Parse("846454D9-DE72-4EF4-ABE2-16EC3710EA0F");
            var warnings = new SqlParameter("warnings", SqlDbType.Structured);
            warnings.Value= dt;
            warnings.TypeName = "dbo.udt_Warnings";
            entities.ExecuteStoreProcedure("usp_RaiseWarnings_rs", userId, warnings, caseId);
            
        }
    }
    public static class ObjectContextExt
    {
        public static void ExecuteStoreProcedure(this ObjectContext context, string storeProcName, params object[] parameters)
        {
            string command = "EXEC " + storeProcName + " @caseid, @userid, @warnings";
          
            context.ExecuteStoreCommand(command, parameters);
        }
    }

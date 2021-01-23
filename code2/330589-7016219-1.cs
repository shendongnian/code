    public partial class UserDefinedFunctions
    {
        private static string GetCommandText(int column)
        {
            return string.Format("select column_{0} from table", column);
        }
    
        [Microsoft.SqlServer.Server.SqlFunction(
            DataAccess = DataAccessKind.Read,
            TableDefinition = "result decimal",
            FillRowMethodName = "FillRow",
            SystemDataAccess = SystemDataAccessKind.Read)]
        public static IEnumerable fnSum(int columnNo)
        {
            var values = new List<long>();
    
            using (var cmd = new SqlCommand(GetCommandText(columnNo), new SqlConnection("context connection=true")))
            {
                cmd.Connection.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
    					values.Add(reader.GetInt64(0));
                    }
                }
            }
    
            return list;
        }
    
        private static void FillRow(object obj, out decimal result)
        {
            var values = (List<long>)obj;
    
    		result = values.Sum(value => (decimal) value);
        }
    }

    class DBOperations
     public abstract string ParameterStringFormat;
     ...
    for (int i = 0; i < values.Length; i++)
            {        
                sql.Append(String.Format(ParamterStringFormat, columns[i].ColumnName)); // SQL Server
            }  
 
    class SqlDbOperations : DBOperations
     public override string ParameterStringFormat { get { return "@{0}"; }}
    class OracleDBOperations : DBOperations
     public override string ParameterStringFormat { get { return ":{0}"; }}

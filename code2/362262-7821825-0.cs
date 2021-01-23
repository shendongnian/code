    class Program
        {
            static void Main(string[] args)
            {
                using (SqlConnection con = new SqlConnection("server=myserver;database=mydb;user id=sa;password=mypassword;"))
                {
                                    
                    Console.WriteLine(GetCreateTableFromSqlCode(@"
    SELECT ID,Eid,Keyword AS Keywords,KeywordType AS Sources,Year
    FROM Eid_Keywords 
    WHERE Eid IN(SELECT Eid FROM ReviewersPublications)","Keywords",con));                
    
                }
            }
    
            public static string GetCreateTableFromSqlCode(string sqlSelect,string tableName, SqlConnection con)
            {            
                SqlCommand cmd = new SqlCommand(string.Format("SET FMTONLY ON;\r\n{0}\r\nSET FMTONLY OFF;",sqlSelect), con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = reader.GetSchemaTable();
                    reader.Close();
                    return GetCreateTableScript(dt, tableName);
                    
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                
            }
    
            private static string GetCreateTableScript(DataTable dt,string tableName)
            {
                string snip = string.Empty;
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("CREATE TABLE {0}\r\n(\r\n",tableName);
                for (int i = 0; i < dt.Rows.Count;i++)
                {
                    DataRow dr = dt.Rows[i];
                    snip = GetColumnSql(dr);
                    sql.AppendFormat((i < dt.Rows.Count - 1) ? snip : snip.TrimEnd(',','\r','\n'));
                }
                sql.AppendFormat("\r\n)");
                return sql.ToString();
            }
    
    
            private static string GetColumnSql(DataRow dr)
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("\t[{0}] {1}{2} {3} {4},\r\n",
                    dr["ColumnName"].ToString(),
                    dr["DataTypeName"].ToString(),
                    (HasSize(dr["DataTypeName"].ToString())) ? "(" + dr["ColumnSize"].ToString() + ")" : (HasPrecisionAndScale(dr["DataTypeName"].ToString())) ? "(" + dr["NumericPrecision"].ToString() + "," + dr["NumericScale"].ToString() + ")" : "",
                    (dr["IsIdentity"].ToString() == "true") ? "IDENTITY" : "",
                    (dr["AllowDBNull"].ToString() == "true") ? "NULL" : "NOT NULL");
                return sql.ToString();
            }
    
            private static bool HasSize(string dataType)
            {            
                Dictionary<string, bool> dataTypes = new Dictionary<string, bool>();
                dataTypes.Add("bigint", false);
                dataTypes.Add("binary", true);
                dataTypes.Add("bit", false);
                dataTypes.Add("char", true);
                dataTypes.Add("date", false);
                dataTypes.Add("datetime", false);
                dataTypes.Add("datetime2", false);
                dataTypes.Add("datetimeoffset", false);
                dataTypes.Add("decimal", false);
                dataTypes.Add("float", false);
                dataTypes.Add("geography", false);
                dataTypes.Add("geometry", false);
                dataTypes.Add("hierarchyid", false);
                dataTypes.Add("image", true);
                dataTypes.Add("int", false);
                dataTypes.Add("money", false);
                dataTypes.Add("nchar", true);
                dataTypes.Add("ntext", true);
                dataTypes.Add("numeric", false);
                dataTypes.Add("nvarchar", true);
                dataTypes.Add("real", false);
                dataTypes.Add("smalldatetime", false);
                dataTypes.Add("smallint", false);
                dataTypes.Add("smallmoney", false);
                dataTypes.Add("sql_variant", false);
                dataTypes.Add("sysname", false);
                dataTypes.Add("text", true);
                dataTypes.Add("time", false);
                dataTypes.Add("timestamp", false);
                dataTypes.Add("tinyint", false);
                dataTypes.Add("uniqueidentifier", false);
                dataTypes.Add("varbinary", true);
                dataTypes.Add("varchar", true);
                dataTypes.Add("xml", false);
                if (dataTypes.ContainsKey(dataType))
                    return dataTypes[dataType];
                return false;
            }
    
            private static bool HasPrecisionAndScale(string dataType)
            {
                Dictionary<string, bool> dataTypes = new Dictionary<string, bool>();
                dataTypes.Add("bigint", false);
                dataTypes.Add("binary", false);
                dataTypes.Add("bit", false);
                dataTypes.Add("char", false);
                dataTypes.Add("date", false);
                dataTypes.Add("datetime", false);
                dataTypes.Add("datetime2", false);
                dataTypes.Add("datetimeoffset", false);
                dataTypes.Add("decimal", true);
                dataTypes.Add("float", true);
                dataTypes.Add("geography", false);
                dataTypes.Add("geometry", false);
                dataTypes.Add("hierarchyid", false);
                dataTypes.Add("image", false);
                dataTypes.Add("int", false);
                dataTypes.Add("money", false);
                dataTypes.Add("nchar", false);
                dataTypes.Add("ntext", false);
                dataTypes.Add("numeric", false);
                dataTypes.Add("nvarchar", false);
                dataTypes.Add("real", true);
                dataTypes.Add("smalldatetime", false);
                dataTypes.Add("smallint", false);
                dataTypes.Add("smallmoney", false);
                dataTypes.Add("sql_variant", false);
                dataTypes.Add("sysname", false);
                dataTypes.Add("text", false);
                dataTypes.Add("time", false);
                dataTypes.Add("timestamp", false);
                dataTypes.Add("tinyint", false);
                dataTypes.Add("uniqueidentifier", false);
                dataTypes.Add("varbinary", false);
                dataTypes.Add("varchar", false);
                dataTypes.Add("xml", false);
                if (dataTypes.ContainsKey(dataType))
                    return dataTypes[dataType];
                return false;
            }
    
    
    
        }

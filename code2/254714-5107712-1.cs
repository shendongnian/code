    class SqlRetriever {
            public const string SQLCmd1 = "...";
            public const string SQLCmd2 = "...";
    
            public void SendSqlCmd(string sqlcmd)
            {
                 /*Send the SQL Cmd and store the result in the list */
            }
    
            public ArrayList List {
                get; set;
            }
    
            public static ArrayList DoSqlCmd(string sqlCmd)
            {
                 var obj = new SqlRetriever();
    
                 obj.SendSqlCmd( sqlCmd );
    
                 return obj.List;
            }
    }

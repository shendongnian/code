        public static CrmServiceClient getCrmServiceClient(string connectionString)
        {
            CrmServiceClient conn;
            conn = new CrmServiceClient(connectionString);
            while (conn.IsReady == false)
            {
                conn = new CrmServiceClient(connectionString);
                if(conn.IsReady == false)
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }
            return conn;
        }

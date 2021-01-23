        public OdbcConnection GetConn()
        {
            OdbcConnectionStringBuilder sb = new OdbcConnectionStringBuilder();
            sb.Driver = "Microsoft Access Driver (*.mdb)";
            sb.Add("Dbq", "C:\\info.mdb");
            sb.Add("Uid", "Admin");
            sb.Add("Pwd", "pass!word1");
            OdbcConnection con = new OdbcConnection(sb.ConnectionString);
            return con;
        }
        public void DoSomeWork()
        {
            using(OdbcConnection connection = GetConn())
            {
                // Do stuff with your connection here
            }
        }

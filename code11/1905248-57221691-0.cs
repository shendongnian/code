        public class Shell
        {
            public string shellURL { get; set; }
            public string shellStatus { get; set; }
            public Shell(string shellURL, string shellStatus)
            {
                this.shellURL = shellURL;
                this.shellStatus = shellStatus;
            }
            public DataTable BuildTable(List<Shell> shells)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("URL", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                foreach(Shell shell in shells)
                {
                    dt.Rows.Add(new object[] { shell.shellURL, shell.shellStatus});
                }
                return dt;
            }|
        }

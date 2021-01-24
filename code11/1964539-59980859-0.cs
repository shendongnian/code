        public class NextCare
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
            public string Field3 { get; set; }
            public NextCare(string f1, string f2, string f3)
            {
                Field1 = f1;
                Field2 = f2;
                Field3 = f3;
            }
        }
        private List<NextCare> OpCode()
        {
            DataTable dt = new DataTable();
            List<NextCare> lst = new List<NextCare>();
            using (MySqlConnection cn = new MySqlConnection("Your connection string"))
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM nextcare_form;", cn))
            {
                cn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            foreach (DataRow row in dt.Rows)
            {
                NextCare nc = new NextCare(row[0].ToString(), row[1].ToString(), row[2].ToString());
                lst.Add(nc);
            }
            return lst;
        }

        class Values
        {
            public string Val1 { get; set; }
            public string Val2 { get; set; }
            public Values(string v1,string v2)
            {
                Val1 = v1;
                Val2 = v2;
            }
        }
        private void InsertValues()
        {
            List<Values> lst = ReadFile();
            using (MySqlConnection cn = new MySqlConnection("Your connection string"))
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `interactions` (`id`, `id_interaction`) VALUES (@id, @idInteraction);", cn))
            {
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50);
                cmd.Parameters.Add("@idInteraction", MySqlDbType.VarChar, 100);
                cn.Open();
                foreach (Values v in lst)
                {
                    cmd.Parameters["@id"].Value = v.Val1;
                    cmd.Parameters["@idInteraction"].Value = v.Val2;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private List<Values> ReadFile()
        {
            List<Values> lst = new List<Values>();
            string[] lines = File.ReadAllLines(@"C:\Users\Edges.txt");
            foreach (string line in lines)
            {
                string[] vals = line.Split(',');
                Values v = new Values(vals[0].Trim(), vals[1].Trim());
                lst.Add(v);
            }
            return lst;
        }

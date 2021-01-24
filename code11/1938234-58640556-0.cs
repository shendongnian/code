        public string AutoID()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Your connection string"))
            {
                using (SqlCommand cmd = new SqlCommand("select pid from passanger", con))
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            int k = dt.Rows.Count;
            if (k == 0)
            {
                return "C0001";
            }
            else
            {
                DataRow r1 = dt.Rows[k - 1];
                string oldID = r1["pid"].ToString();
                int i = int.Parse(oldID.Substring(1));
                i += 1;
                string newID = i.ToString();
                newID = newID.PadLeft(4, '0');
                newID = "C" + newID;
                return newID;
            }
        }

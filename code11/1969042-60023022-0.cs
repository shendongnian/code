        private void Button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("persons.txt");
            Person[] persons = new Person[lines.Length];
            int index = 0;
            foreach (string s in lines)
            {
                string[] arr = s.Split(',');
                persons[index] = new Person(arr[0], arr[1], arr[2]);
            }
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.CoffeeConnection))
            using (SqlCommand cmd = new SqlCommand("Select * From Person Where FirstName = @FName And MiddleName = @MName And LastName = @LName;", cn))
            {
                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@MName", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("LName", SqlDbType.VarChar, 100);
                cn.Open();
                foreach (Person p in persons)
                {
                    cmd.Parameters["@FName"].Value = p.firstName;
                    cmd.Parameters["@MName"].Value = p.middleName;
                    cmd.Parameters["@LName"].Value = p.lastName;
                    dt.Load(cmd.ExecuteReader());
                }
            }
            dataGridView1.DataSource = dt;
        }

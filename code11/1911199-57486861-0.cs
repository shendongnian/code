        void FillData()
        {
            comboBox1.Items.Clear(); // clear items before each search
            string constring = (@"Data Source=(local);Initial Catalog=UnifaceDB;Integrated Security=True");
            string Query = "select Code,Module1,Module2,Module3 from prof where Code=@code"; // command parameter used instead of direct string concatenation
            using (SqlConnection conDataBase = new SqlConnection(constring))
            {
                using (SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase))
                {
                    cmdDataBase.Parameters.AddWithValue("@Code", txtAssignement.Text); // apply command parameter
                    conDataBase.Open();
                    using (SqlDataReader myReader = cmdDataBase.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            string sName = myReader.GetString(myReader.GetOrdinal("Module1"));
                            comboBox1.Items.Add(sName);
                            string sName2 = myReader.GetString(myReader.GetOrdinal("Module2"));
                            comboBox1.Items.Add(sName2);
                            string sName3 = myReader.GetString(myReader.GetOrdinal("Module3"));
                            comboBox1.Items.Add(sName3);
                        }
                    }
                }
            }
        }

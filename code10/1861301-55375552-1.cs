        void search1Thread_Dowrk(object sender, DoWorkEventArgs e)
        {
            int percentprogress = 0;
            percentprogress++;
            Thread.Sleep(1000);
            // Search1 button event handler
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlDataAdapter cmd = new SqlDataAdapter(comboBox1SQL, conn))
                {
                    if (comboBox1_Text.Contains("ID"))
                    {
                        long para = long.Parse(search1_Text);
                        cmd.SelectCommand.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@combo1Par",
                            Value = para,
                            SqlDbType = SqlDbType.BigInt
                        });
                    }
                    else if (comboBox1_Text.Contains("Other Thing") || comboBox1_Text.Contains("Other Stuff"))
                    {
                        string para = search1_Text;
                        cmd.SelectCommand.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@combo1Par",
                            Value = "%" + para + "%",
                            SqlDbType = SqlDbType.NVarChar,
                        });
                    }
                    // Clear datatable if it contains any information and then fill it
                    // tab1datatable is a DataGridView
                    if (tab1table != null)
                        tab1table.Clear();
                    cmd.Fill(tab1table);
                    //tab1datatable.DataSource = tab1table;
                    // A bunch of expensive calculations 
                }
            }
        }

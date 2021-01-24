 string text = "";
            foreach (String s in textBox1.Text.Split('\n'))
            {
                text +="'"+ s+"',";
            }
            text = text.TrimEnd(',');
this will help you achieve what you need. you can ask If there is any confusion.
Your final code will become :
public void GetData()
        {
            if (string.IsNullOrWhiteSpace(textbox1.Text) || textbox1.Text == "")
            {
                MessageBox.Show("Please Enter at least 1 Value and Try Again!");
            }
            else
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                // string[] lines = textbox1.Text.Split('\n');
                string text = "";
                foreach (String s in textBox1.Text.Split('\n'))
                {
                    text += "'" + s + "',";
                }
                text = text.TrimEnd(',');
                //Connection Credentials
                string credentials = "Credentials";
                string query = "SELECT dummyCol FROM dummytable WHERE IN altCol = '" + text + "'";
                OracleConnection conn = new OracleConnection(credentials);
                try
                {
                    //Open The Connection
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        //Call the Oracle Reader
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Unable to Retrieve Data");
                                return;
                            }
                            else if (reader.HasRows)
                            {
                                reader.Read();
                                DataRow row = dt.NewRow();
                                // create variables to accept reader data for each column
                                // insert data from query into each column here
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
         }
        }

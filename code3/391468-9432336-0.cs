        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int foreignKey = (int)cboMake.SelectedIndex +1;   // i forgot to cast the int from string since the database was tinyint, it still returns string in c#
            string fk = foreignKey.ToString();   // since i need the string for the query, back it goes, but i needed to do arithmetic 
            string connStr = "server=10.18.30.1;user=notroot;database=car;port=3306;password=password";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                string sql = "SELECT * FROM cs_model WHERE mid=" + fk;   // forgot to escape out of the string (used to php $var style within double quotes)
                MySqlCommand cmd = new MySqlCommand(sql, conn);                    
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                cboModel.DataSource = dt;           // i had cboModel by a silly mistake
                cboModel.DisplayMember = "model";
                cboModel.ValueMember = "mmid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MySQL Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();            
        }
